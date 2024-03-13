using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Services.Data.Models.House;
using HouseRentingSystem.Web.ViewModels.Home;
using HouseRentingSystem.Web.ViewModels.House;
using HouseRentingSystem.Web.ViewModels.House.Enums;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Data;

public class HouseService : IHouseService
{
	private readonly HouseRentingDbContext dbContext;

	public HouseService(HouseRentingDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	public async Task<AllHousesFilteredAndPagedServiceModel> AllAsync(AllHousesQueryModel queryModel)
	{
		IQueryable<House> housesQuery = dbContext
			.Houses
			.AsQueryable();

		if (!string.IsNullOrWhiteSpace(queryModel.Category))
		{
			housesQuery = housesQuery
				.Where(h => h.Category.Name == queryModel.Category);
		}

		if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
		{
			string wildCard = $"%{queryModel.SearchString.ToLower()}%";

			housesQuery = housesQuery
				.Where(h => EF.Functions.Like(h.Title, wildCard) ||
								 EF.Functions.Like(h.Address, wildCard) ||
								 EF.Functions.Like(h.Description, wildCard));
		}

		housesQuery = queryModel.HouseSorting switch
		{
			HouseSorting.Newest => housesQuery
							.OrderByDescending(h => h.CreatedOn),
			HouseSorting.Oldest => housesQuery
							.OrderBy(h => h.CreatedOn),
			HouseSorting.PriceDescending => housesQuery
							.OrderByDescending(h => h.PricePerMonth),
			HouseSorting.PriceAscending => housesQuery
							.OrderBy(h => h.PricePerMonth),
			_ => housesQuery
				.OrderBy(h => h.RenterId != null)
				.ThenByDescending(h => h.CreatedOn)
		};

		IEnumerable<HouseAllViewModel> allHouses = await housesQuery
			.Where(h => h.isActive)
			.Skip((queryModel.CurrentPage - 1) * queryModel.HousesPerPage)
			.Take(queryModel.HousesPerPage)
			.Select(h => new HouseAllViewModel
			{
				Id = h.Id.ToString(),
				Title = h.Title,
				Address = h.Address,
				ImageUrl = h.ImageUrl,
				PricePerMonth = h.PricePerMonth,
				IsRented = h.RenterId.HasValue
			})
			.ToArrayAsync();

		int totalHouses = housesQuery.Count();

		return new AllHousesFilteredAndPagedServiceModel()
		{
			Houses = allHouses,
			TotalHousesCount = totalHouses
		};
	}

	public async Task<IEnumerable<HouseAllViewModel>> AllByAgentIdAsync(string agentId)
		=> await dbContext
			.Houses
			.AsNoTracking()
			.Where(h => h.AgentId.ToString() == agentId
							&& h.isActive == true)
			.Select(h => new HouseAllViewModel
			{
				Id = h.Id.ToString(),
				Title = h.Title,
				Address = h.Address,
				ImageUrl = h.ImageUrl,
				PricePerMonth = h.PricePerMonth,
				IsRented = h.RenterId.HasValue
			})
			.ToArrayAsync();

	public async Task<IEnumerable<HouseAllViewModel>> AllByUserIdAsync(string userId)
	=> await dbContext
			.Houses
			.AsNoTracking()
			.Where(h => h.RenterId.HasValue == true
							&& h.RenterId.ToString() == userId
							&& h.isActive == true)
			.Select(h => new HouseAllViewModel
			{
				Id = h.Id.ToString(),
				Title = h.Title,
				Address = h.Address,
				ImageUrl = h.ImageUrl,
				PricePerMonth = h.PricePerMonth,
				IsRented = h.RenterId.HasValue
			})
			.ToArrayAsync();

	public async Task CreateAsync(HouseFormModel houseModel, string agentId)
	{
		House newHouse = new()
		{
			Title = houseModel.Title,
			Address = houseModel.Address,
			Description = houseModel.Description,
			ImageUrl = houseModel.ImageUrl,
			PricePerMonth = houseModel.PricePerMonth,
			CategoryId = houseModel.CategoryId,
			AgentId = Guid.Parse(agentId),
		};

		await dbContext.Houses.AddAsync(newHouse);
		await dbContext.SaveChangesAsync();
	}

	public async Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync()
	{
		IEnumerable<IndexViewModel> lastThreeHouses = await dbContext
			.Houses
			.AsNoTracking()
			.Where(h => h.isActive)
			.OrderByDescending(h => h.CreatedOn)
			.Select(h => new IndexViewModel
			{
				Id = h.Id.ToString(),
				Title = h.Title,
				ImageUrl = h.ImageUrl,
			})
			.Take(3)
			.ToArrayAsync();

		return lastThreeHouses;
	}
}
