using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto;

[XmlType("Cast")]
public class ImportCastDto
{
    [XmlElement]
    [Required]
    [MinLength(ValidationConstants.CastFullNameMinLength)]
    [MaxLength(ValidationConstants.CastFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [XmlElement]
    [Required]
    public bool IsMainCharacter { get; set; }

    [XmlElement]
    [Required]
    [MaxLength(ValidationConstants.CastPhoneNumberLength)]
    [RegularExpression(ValidationConstants.CastPhoneNumberRegex)]
    public string PhoneNumber { get; set; } = null!;

    [XmlElement]
    [Required]
    public int PlayId { get; set; }
}
