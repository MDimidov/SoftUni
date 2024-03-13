#nullable disable

using HouseRentingSystem.Web.ViewModels.Agent;

namespace HouseRentingSystem.Web.ViewModels.House;

public class HouseDetailsViewModel : HouseAllViewModel
{
	public string Description { get; set; }

	public string Category { get; set; }

	public AgentInfoOnHouseViewModel Agent {  get; set; }
}
