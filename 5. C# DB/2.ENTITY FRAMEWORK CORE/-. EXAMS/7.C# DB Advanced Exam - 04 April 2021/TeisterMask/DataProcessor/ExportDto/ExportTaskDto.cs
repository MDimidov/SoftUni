using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto;

[XmlType("Task")]
public class ExportTaskDto
{
    [XmlElement]
    public string Name { get; set; } = null!;

    [XmlElement]
    public string Label { get; set; } = null!;
}
