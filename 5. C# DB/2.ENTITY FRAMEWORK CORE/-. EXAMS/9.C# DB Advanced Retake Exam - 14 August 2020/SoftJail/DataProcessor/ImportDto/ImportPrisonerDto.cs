using SoftJail.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto;

public class ImportPrisonerDto
{
    [Required]
    [MinLength(ValidationConstants.PrisonerFullNameMinLength)]
    [MaxLength(ValidationConstants.PrisonerFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    [RegularExpression(ValidationConstants.PrisonerNicknameRegex)]
    public string Nickname { get; set; } = null!;

    [Required]
    [Range(ValidationConstants.PrisonerAgeMinRange, ValidationConstants.PrisonerAgeMaxRange)]
    public int Age { get; set; }

    [Required]
    public string IncarcerationDate { get; set; } = null!;

    public string? ReleaseDate { get; set; }

    [Range(ValidationConstants.PrisoberBailMinRange, ValidationConstants.PrisoberBailMaxRange)]
    public decimal? Bail { get; set; }

    public int? CellId { get; set; }

    public ImportMailDto[] Mails { get; set; } = null!;
}
