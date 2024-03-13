using HouseRentingSystem.Services.Data.Models.House;
using HouseRentingSystem.Web.ViewModels.Home;
using HouseRentingSystem.Web.ViewModels.House;

namespace HouseRentingSystem.Services.Data.Interfaces;

public interface IHouseService
{
	Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync();

	Task CreateAsync(HouseFormModel houseModel, string agentId);

	Task<AllHousesFilteredAndPagedServiceModel> AllAsync(AllHousesQueryModel queryModel);

	Task<IEnumerable<HouseAllViewModel>> AllByAgentIdAsync(string agentId);

	Task<IEnumerable<HouseAllViewModel>> AllByUserIdAsync(string userId);

	Task<bool> ExistByIdAsync(string houseId);


	Task<HouseDetailsViewModel> GetDetailsByIdAsync(string houseId);

	Task<HouseFormModel> GetHouseForEditByIdAsync(string houseId);
}
