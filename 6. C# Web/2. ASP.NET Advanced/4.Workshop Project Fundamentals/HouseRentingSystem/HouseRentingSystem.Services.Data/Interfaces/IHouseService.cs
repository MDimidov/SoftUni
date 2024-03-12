using HouseRentingSystem.Web.ViewModels.Home;
using HouseRentingSystem.Web.ViewModels.House;

namespace HouseRentingSystem.Services.Data.Interfaces;

public interface IHouseService
{
	Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync();

	Task CreateAsync(HouseFormModel houseModel, string agentId);
}
