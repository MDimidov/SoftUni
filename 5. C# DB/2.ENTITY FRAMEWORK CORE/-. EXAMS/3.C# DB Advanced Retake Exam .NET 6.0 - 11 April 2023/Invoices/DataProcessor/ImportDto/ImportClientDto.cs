using Invoices.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto;

[XmlType("Client")]
public class ImportClientDto
{
    [XmlElement]
    [Required]
    [MinLength(ValidationConstants.ClientNameMinLength)]
    [MaxLength(ValidationConstants.ClientNameMaxLength)]
    public string Name { get; set; } = null!;

    [XmlElement]
    [Required]
    [MinLength(ValidationConstants.ClientNumberVatMinLength)]
    [MaxLength(ValidationConstants.ClientNumberVatMaxLength)]
    public string NumberVat { get; set; } = null!;

    [XmlArray("Addresses")]
    public ImportAddressDto[] Addresses { get; set; } = null!;
}
