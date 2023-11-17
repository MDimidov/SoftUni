using Boardgames.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType("Creator")]
public class ImportCreatorDto
{
    [XmlElement]
    [Required]
    [MinLength(ValidationConstants.CreatorFirstNameMinLength)]
    [MaxLength(ValidationConstants.CreatorFirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [XmlElement]
    [Required]
    [MinLength(ValidationConstants.CreatorLastNameMinLength)]
    [MaxLength(ValidationConstants.CreatorLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [XmlArray]
    public ImportBoardgameDto[] Boardgames { get; set; } = null!;
}
