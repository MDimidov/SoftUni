using Artillery.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto;

[XmlType("Country")]
public class ImportCountryDto
{
    [XmlElement]
    [Required]
    [MinLength(ValidationConstants.CountryNameMinLength)]
    [MaxLength(ValidationConstants.CountryNameMaxLength)]
    public string CountryName { get; set; } = null!;

    [Required]
    [XmlElement]
    [Range(ValidationConstants.CountryArmySizeMinRange, ValidationConstants.CountryArmySizeMaxRange)]
    public int ArmySize { get; set; }
}
