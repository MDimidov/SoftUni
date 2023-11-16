using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto;

[XmlType("Despatcher")]
public class ExportDespatcherDto
{
    [XmlAttribute("TrucksCount")]
    public int TrucksCount { get; set; }

    [XmlElement]
    public string DespatcherName { get; set; } = null!;

    [XmlArray]
    public ExportTruckDto[] Trucks { get; set; } = null!;
}
