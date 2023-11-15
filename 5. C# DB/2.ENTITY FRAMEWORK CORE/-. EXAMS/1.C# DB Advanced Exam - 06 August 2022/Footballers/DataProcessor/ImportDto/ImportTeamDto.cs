using Footballers.Common;
using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto;

public class ImportTeamDto
{
    [MinLength(ValidationConstraints.TeamNameMinLength)]
    [MaxLength(ValidationConstraints.TeamNameMaxLength)]
    [RegularExpression(ValidationConstraints.TeamNameRegex)]
    public string Name { get; set; } = null!;

    [MaxLength(ValidationConstraints.TeamNationalityMaxLength)]
    [MinLength(ValidationConstraints.TeamNationalityMinLength)]
    public string Nationality { get; set; } = null!;

    public int Trophies { get; set; }

    public int[] Footballers { get; set; } = null!;
}
