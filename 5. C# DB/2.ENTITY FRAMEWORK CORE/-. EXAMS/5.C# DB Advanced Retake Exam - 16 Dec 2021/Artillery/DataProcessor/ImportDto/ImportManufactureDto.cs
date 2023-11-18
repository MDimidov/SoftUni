using Artillery.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto;

[XmlType("Manufacturer")]
public class ImportManufactureDto
{
    [XmlElement]
    [Required]
    [MinLength(ValidationConstants.ManufacturerNameMinLength)]
    [MaxLength(ValidationConstants.ManufacturerNameMaxLength)]
    public string ManufacturerName { get; set; } = null!;

    [XmlElement]
    [Required]
    [MinLength(ValidationConstants.ManufacturerFoundedMinLength)]
    [MaxLength(ValidationConstants.ManufacturerFoundedMaxLength)]
    public string Founded { get; set; } = null!;
}
