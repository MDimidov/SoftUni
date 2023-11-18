using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto;

[XmlType("Country")]
public class ExportCountryDto
{
    [XmlAttribute]
    public string Country { get; set; } = null!;

    [XmlAttribute]
    public int ArmySize { get; set; }
}
