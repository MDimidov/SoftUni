using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.DataProcessor.ImportDto;

public class ImportCardDto
{
    [Required]
    [RegularExpression(ValidationConstants.CardNumberRegex)]
    public string Number { get; set; } = null!;

    [Required]
    [RegularExpression(ValidationConstants.CardCvcRegex)]
    public string CVC { get; set; } = null!;

    [Required]
    public string Type { get; set; } = null!;
}
