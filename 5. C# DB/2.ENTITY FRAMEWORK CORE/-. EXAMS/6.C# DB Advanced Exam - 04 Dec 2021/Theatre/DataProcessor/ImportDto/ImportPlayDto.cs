using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Serialization;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto;

[XmlType("Play")]
public class ImportPlayDto
{
    [Required]
    [XmlElement]
    [MinLength(ValidationConstants.PlayTitleMinLength)]
    [MaxLength(ValidationConstants.PlayTitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [XmlElement]
    public string Duration { get; set; } = null!;

    [Required]
    [XmlElement("Raiting")]
    [Range(ValidationConstants.PlayRatingMinRange, ValidationConstants.PlayRatingMaxRange)]
    public double Rating { get; set; }

    [Required]
    [XmlElement]
    public string Genre { get; set; } = null!;

    [Required]
    [XmlElement]
    [MaxLength(ValidationConstants.PlayDescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required]
    [XmlElement]
    [MinLength(ValidationConstants.PlayScreenwriterMinLength)]
    [MaxLength(ValidationConstants.PlayScreenwriterMaxLength)]
    public string Screenwriter { get; set; } = null!;
}
