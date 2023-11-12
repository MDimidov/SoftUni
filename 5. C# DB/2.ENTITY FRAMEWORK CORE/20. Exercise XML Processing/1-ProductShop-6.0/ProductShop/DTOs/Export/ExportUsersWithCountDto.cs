using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("Users")]
public class ExportUsersWithCountDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("users")]
    public ExportUserWithProductsDto[] Users { get; set; } = null!;
}
