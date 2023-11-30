using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto;

[XmlType("Message")]
public class EportMailDto
{
    [XmlElement]
    public string Description { get; set; } = null!;
}
