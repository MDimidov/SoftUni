using FastFood.Common.EntityConfig;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Positions;

public class CreatePositionInputModel
{
    [MinLength(ViewModelsValidation.PositionNameMinLength)]
    [MaxLength(ViewModelsValidation.PositionNameMaxLength)]
    //[StringLength(ViewModelsValidation.PositionNameMaxLength, MinimumLength = ViewModelsValidation.PositionNameMinLength)]
    public string PositionName { get; set; } = null!;
}