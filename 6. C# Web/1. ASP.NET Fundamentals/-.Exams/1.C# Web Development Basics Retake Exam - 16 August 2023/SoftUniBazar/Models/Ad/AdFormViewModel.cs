#nullable disable

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.ErrorMessages;
using static SoftUniBazar.Common.ValidationConstants.Ad;
using SoftUniBazar.Models.Category;


namespace SoftUniBazar.Models.Ad;

public class AdFormViewModel
{

    public AdFormViewModel()
    {
        Categories = new HashSet<CategoryViewModel>();
    }

    [Required(ErrorMessage = RequiredField)]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength,
        ErrorMessage = RequiredLength)]
    public string Name { get; set; }

    [Required(ErrorMessage = RequiredField)]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
        ErrorMessage = RequiredLength)]
    public string Description { get; set; }


    [Required(ErrorMessage = RequiredField)]
    public decimal Price { get; set; }

    [Required(ErrorMessage = RequiredField)]
    public string ImageUrl { get; set; }

    [Required(ErrorMessage = RequiredField)]
    public int CategoryId { get; set; }

    public IEnumerable<CategoryViewModel> Categories { get; set; }
}