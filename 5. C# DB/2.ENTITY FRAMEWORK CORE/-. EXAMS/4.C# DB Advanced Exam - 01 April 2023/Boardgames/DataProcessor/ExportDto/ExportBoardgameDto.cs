using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto;

[XmlType("Boardgame")]
public class ExportBoardgameDto
{
    [XmlElement]
    public string BoardgameName { get; set; } = null!;

    [XmlElement]
    public int BoardgameYearPublished { get; set; }
}
