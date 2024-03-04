using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.ViewModels.Home;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Data;

public class HouseService : IHouseService
{
	private readonly HouseRentingDbContext dbContext;

	public HouseService(HouseRentingDbContext dbContext)
	{
		this.dbContext = dbContext;
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
