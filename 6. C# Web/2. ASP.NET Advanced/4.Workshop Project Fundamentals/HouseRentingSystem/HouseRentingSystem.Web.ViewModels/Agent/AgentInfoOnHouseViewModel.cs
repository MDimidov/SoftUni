#nullable disable

using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Web.ViewModels.Agent;

public class AgentInfoOnHouseViewModel
{
	public string Email { get; set; }


	[Display(Name = "Phone")]
	public string PhoneNumber { get; set; }
}
