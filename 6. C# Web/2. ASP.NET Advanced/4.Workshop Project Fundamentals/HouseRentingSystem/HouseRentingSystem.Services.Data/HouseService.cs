using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.ViewModels.Home;
using HouseRentingSystem.Web.ViewModels.House;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Data;

public class HouseService : IHouseService
{
	private readonly HouseRentingDbContext dbContext;

	public HouseService(HouseRentingDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

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
