#nullable disable

using HouseRentingSystem.Web.ViewModels.Category;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Common.EntityValidationConstants.House;

namespace HouseRentingSystem.Web.ViewModels.House;

public class HouseFormModel
{

    [Required]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
    public string Title { get; set; }

    [Required]
    [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
    public string Address { get; set; }

    [Required]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
    public string Description { get; set; }

    [Required]
    [StringLength(ImageUrlMaxLength)]
    [Display(Name = "Image link")]
    public string ImageUrl { get; set; }

    [Range(typeof(decimal), PricePerMonthMinRange, PricePerMonthMaxRange)]
    [Display(Name = "Monthly price")]
    public decimal PricePerMonth { get; set; }

    [Display(Name = "Category")]
    public int CategoryId { get; set; }
    public IEnumerable<HouseSelectCategoryFormModel> Categories { get; set; } = new HashSet<HouseSelectCategoryFormModel>();
}
