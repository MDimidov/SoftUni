using Boardgames.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType("Boardgame")]
public class ImportBoardgameDto
{
    [Required]
    [XmlElement]
    [MinLength(ValidationConstants.BoardgameNameMinLength)]
    [MaxLength(ValidationConstants.BoardgameNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement]
    [Range(ValidationConstants.BoardgameRatingMinRange, ValidationConstants.BoardgameRatingMaxRange)]
    public double Rating { get; set; }

    [Required]
    [XmlElement]
    [Range(ValidationConstants.BoardgameYearPublishedMinRange, ValidationConstants.BoardgameYearPublishedMaxRange)]
    public int YearPublished { get; set; }

    [Required]
    [XmlElement]
    [Range(0, ValidationConstants.BoardgameCategoryTypeMaxRange)]
    public int CategoryType { get; set; }

    [Required]
    [XmlElement]
    public string Mechanics { get; set; } = null!;
}
