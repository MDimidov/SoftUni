using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos;

[XmlType("Medicine")]
public class ExportMedicineDto
{
    [XmlAttribute]
    public string Category { get; set; } = null!;

    [XmlElement]
    public string Name { get; set; } = null!;

    [XmlElement]
    public string Price { get; set; } = null!;

    [XmlElement]
    public string Producer { get; set; } = null!;

    [XmlElement]
    public string BestBefore { get; set; } = null!;
}
