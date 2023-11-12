using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("SoldProducts")]
public class ExportSoldProductsWithCount
{
    [XmlElement("count")]
    public int Count {  get; set; }

    [XmlArray("products")]
    public ExportProductNamePriceDto[] Products { get; set; } = null!;

}
