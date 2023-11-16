using System.ComponentModel.DataAnnotations;
using Trucks.Common;

namespace Trucks.DataProcessor.ImportDto;

public class ImportClientDto
{
    [MinLength(ValidationConstants.ClientNameMinLength)]
    [MaxLength(ValidationConstants.ClientNameMaxLength)]
    public string Name { get; set; } = null!;

    [MinLength(ValidationConstants.ClientNationalityMinLength)]
    [MaxLength (ValidationConstants.ClientNationalityMaxLength)]
    public string Nationality { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int[] Trucks { get; set; } = null!;
}
