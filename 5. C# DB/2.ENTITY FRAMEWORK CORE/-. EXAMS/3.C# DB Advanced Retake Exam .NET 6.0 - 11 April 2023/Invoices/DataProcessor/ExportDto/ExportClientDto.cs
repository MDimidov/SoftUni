using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto;

[XmlType("Client")]
public class ExportClientDto
{
    [XmlAttribute]
    public int InvoicesCount { get; set; }

    [XmlElement]
    public string ClientName { get; set; } = null!;

    [XmlElement]
    public string VatNumber { get; set; } = null!;

    [XmlArray("Invoices")]
    public ExportInvoiceDto[] Invoices { get; set; } = null!;
}
