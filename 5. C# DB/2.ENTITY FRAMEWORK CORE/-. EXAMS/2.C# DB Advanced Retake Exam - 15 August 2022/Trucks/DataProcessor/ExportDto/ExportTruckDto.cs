using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto;

[XmlType("Truck")]
public class ExportTruckDto
{
    [XmlElement]
    public string RegistrationNumber { get; set; } = null!;

    [XmlElement]
    public string Make { get; set; } = null!;
}
