using FastFood.Common.EntityConfig;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Items
{
    public class CreateItemInputModel
    {
        //[StringLength(ValidationConstants.ItemNameMaxLength, MinimumLength = 3)]
        [MinLength(ViewModelsValidation.ItemNameMinLength)]
        [MaxLength(ViewModelsValidation.ItemNameMaxLength)]
        public string? Name { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
