using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto;

[XmlType("Invoice")]
public class ExportInvoiceDto
{
    [XmlElement]
    public int InvoiceNumber { get; set; }

    [XmlElement]
    public double InvoiceAmount { get; set; }

    [XmlElement]
    public string DueDate { get; set; } = null!;

    [XmlElement]
    public string Currency { get; set;} = null!;
}
