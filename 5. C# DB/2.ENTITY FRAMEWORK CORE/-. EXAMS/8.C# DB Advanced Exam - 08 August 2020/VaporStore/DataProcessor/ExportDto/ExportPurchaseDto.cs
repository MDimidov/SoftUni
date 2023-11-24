using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDto;

[XmlType("Purchase")]
public class ExportPurchaseDto
{
    [XmlElement]
    public string Card { get; set; } = null!;

    [XmlElement]
    public string Cvc {  get; set; } = null!;

    [XmlElement]
    public string Date {  get; set; } = null!;

    [XmlElement]
    public ExportGameDto Game { get; set; } = null!;
}
