using HouseRentingSystem.Services.Data.Models.House;
using HouseRentingSystem.Web.ViewModels.Home;
using HouseRentingSystem.Web.ViewModels.House;

namespace HouseRentingSystem.Services.Data.Interfaces;

public interface IHouseService
{
	Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync();

	Task<string> CreateAndReturnIdAsync(HouseFormModel houseModel, string agentId);

	Task<AllHousesFilteredAndPagedServiceModel> AllAsync(AllHousesQueryModel queryModel);

	Task<IEnumerable<HouseAllViewModel>> AllByAgentIdAsync(string agentId);

	Task<IEnumerable<HouseAllViewModel>> AllByUserIdAsync(string userId);

	Task<bool> ExistByIdAsync(string houseId);


	Task<HouseDetailsViewModel> GetDetailsByIdAsync(string houseId);

	Task<HouseFormModel> GetHouseForEditByIdAsync(string houseId);

	Task<bool> IsAgentWithIdOwnerOfHouseWithIdAsync(string agentId, string houseId);

	Task EditHouseByIdAndFormModelAsync(string houseId, HouseFormModel formModel);

	Task<HousePreDeleteDetailsViewModel> GetHouseForDeleteByIdAsync(string id);

	Task DeleteHouseByIdAsync(string houseId);

	Task<bool> IsRentedByIdAsync(string houseId);

	Task RentHouseAsync(string houseId, string userId);

	Task<bool> IsRentedByUserWithIdAsync(string houseId, string userId);

	Task LeaveHouseAsync(string houseId);
}
