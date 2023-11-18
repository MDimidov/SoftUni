using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto;

[XmlType("Creator")]
public class ExportCreatorDto
{
    [XmlAttribute]
    public int BoardgamesCount { get; set; }

    [XmlElement]
    public string CreatorName { get; set; } = null!;

    [XmlArray]
    public ExportBoardgameDto[] Boardgames { get; set; } = null!;
}
