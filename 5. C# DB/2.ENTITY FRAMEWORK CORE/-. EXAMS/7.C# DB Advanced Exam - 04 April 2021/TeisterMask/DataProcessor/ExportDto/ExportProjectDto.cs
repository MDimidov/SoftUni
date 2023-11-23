using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto;

[XmlType("Project")]
public class ExportProjectDto
{
    [XmlAttribute]
    public int TasksCount { get; set; }

    [XmlElement]
    public string ProjectName { get; set; } = null!;

    [XmlElement]
    public string HasEndDate { get; set; } = null!;

    [XmlArray]
    public ExportTaskDto[] Tasks { get; set; } = null!;
}
