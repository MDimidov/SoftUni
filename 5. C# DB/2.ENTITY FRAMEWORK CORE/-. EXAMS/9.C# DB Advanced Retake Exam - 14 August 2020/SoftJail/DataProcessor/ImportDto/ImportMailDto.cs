using SoftJail.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto;

public class ImportMailDto
{
    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public string Sender { get; set; } = null!;

    [Required]
    [RegularExpression(ValidationConstants.MailAddressRegex)]
    public string Address { get; set; } = null!;
}
