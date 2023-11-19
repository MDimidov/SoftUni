using System.ComponentModel.DataAnnotations;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto;

public class ImportTheatreDto
{
    [Required]
    [MinLength(ValidationConstants.TheatreNameMinLength)]
    [MaxLength(ValidationConstants.TheatreNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [Range(ValidationConstants.TheatreNumberOfHallsMinRange, ValidationConstants.TheatreNumberOfHallsMaxRange)]
    public sbyte NumberOfHalls { get; set; }

    [Required]
    [MinLength(ValidationConstants.TheatreDirectorMinLength)]
    [MaxLength(ValidationConstants.TheatreDirectorMaxLength)]
    public string Director { get; set; } = null!;

    public ImportTicketDto[] Tickets { get; set; } = null!;
}
