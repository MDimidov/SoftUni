#nullable disable

using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Web.ViewModels.House;

public class HouseAllViewModel
{
	public string Id { get; set; }

	public string Title { get; set; }

	public string Address { get; set; }

	[Display(Name = "Image Link")]
	public string ImageUrl { get; set; }

	[Display(Name = "Monthly price")]
	public decimal PricePerMonth { get; set; }

	[Display(Name = "Is rented")]
	public bool IsRented { get; set; } 
}
