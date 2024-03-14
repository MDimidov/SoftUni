#nullable disable

using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Web.ViewModels.House;

public class HousePreDeleteDetailsViewModel
{
	public string Title {  get; set; }

	public string Address { get; set; }

	[Display(Name = "Image Link")]
	public string ImageUrl { get; set; }
}
