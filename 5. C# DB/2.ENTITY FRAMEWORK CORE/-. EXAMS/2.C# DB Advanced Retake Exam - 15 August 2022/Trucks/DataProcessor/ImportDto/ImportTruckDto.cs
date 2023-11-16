using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Common;

namespace Trucks.DataProcessor.ImportDto;

[XmlType("Truck")]
public class ImportTruckDto
{
    [XmlElement("RegistrationNumber")]
    [StringLength(ValidationConstants.TruckRegistrationNumberLength)]
    [RegularExpression(ValidationConstants.TruckRegistrationNumberRegex)]
    public string RegistrationNumber { get; set; }

    [XmlElement("VinNumber")]
    [StringLength(ValidationConstants.TruckVinNumberLength)]
    public string VinNumber { get; set; }

    [XmlElement("TankCapacity")]
    [Range(ValidationConstants.TruckTankCapacityMinRange, ValidationConstants.TruckTankCapacityMaxRange)]
    public int TankCapacity { get; set; }

    [XmlElement("CargoCapacity")]
    [Range(ValidationConstants.TruckCargoCapacityMinRange, ValidationConstants.TruckCargoCapacityMaxRange)]
    public int CargoCapacity { get; set; }

    [XmlElement("CategoryType")]
    [Range(0, 3)]
    public int CategoryType { get; set; }

    [XmlElement("MakeType")]
    [Range(0, 4)]
    public int MakeType { get; set; }

}
