using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Common;

namespace Trucks.DataProcessor.ImportDto;

[XmlType("Truck")]
public class ImportTruckDto
{
    [XmlElement("RegistrationNumber")]
    [MinLength(ValidationConstants.TruckRegistrationNumberLength)]
    [MaxLength(ValidationConstants.TruckRegistrationNumberLength)]
    [RegularExpression(ValidationConstants.TruckRegistrationNumberRegex)]
    public string? RegistrationNumber { get; set; }

    [XmlElement("VinNumber")]
    [Required]
    [MinLength(ValidationConstants.TruckVinNumberLength)]
    [MaxLength(ValidationConstants.TruckVinNumberLength)]
    public string VinNumber { get; set; } = null!;

    [XmlElement("TankCapacity")]
    [Required]
    [Range(ValidationConstants.TruckTankCapacityMinRange, ValidationConstants.TruckTankCapacityMaxRange)]
    public int TankCapacity { get; set; }

    [XmlElement("CargoCapacity")]
    [Required]
    [Range(ValidationConstants.TruckCargoCapacityMinRange, ValidationConstants.TruckCargoCapacityMaxRange)]
    public int CargoCapacity { get; set; }

    [XmlElement("CategoryType")]
    [Required]
    [Range(0, 3)]
    public int CategoryType { get; set; }

    [XmlElement("MakeType")]
    [Required]
    [Range(0, 4)]
    public int MakeType { get; set; }

}
