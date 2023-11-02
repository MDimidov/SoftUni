using FastFood.Common.EntityConfig;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Categories;

public class CreateCategoryInputModel
{
    [MinLength(ViewModelsValidation.CategoryNameMinLength)]
    [MaxLength(ViewModelsValidation.CategoryNameMaxLength)]
    public string CategoryName { get; set; } = null!;
}
