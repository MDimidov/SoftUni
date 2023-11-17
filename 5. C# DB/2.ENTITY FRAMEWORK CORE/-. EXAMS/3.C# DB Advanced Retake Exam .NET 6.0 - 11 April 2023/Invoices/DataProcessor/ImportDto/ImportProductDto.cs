using Invoices.Common;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto;

public class ImportProductDto
{
    [Required]
    [MinLength(ValidationConstants.ProductNameMinLength)]
    [MaxLength(ValidationConstants.ProductNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [Range(ValidationConstants.ProductPriceMinRange, ValidationConstants.ProductPriceMaxRange)]
    public decimal Price { get; set; }

    [Required]
    [Range(0, ValidationConstants.ProductCategoryTypeMaxRange)]
    public int CategoryType { get; set; }

    public int[] Clients { get; set; } = null!;
}
