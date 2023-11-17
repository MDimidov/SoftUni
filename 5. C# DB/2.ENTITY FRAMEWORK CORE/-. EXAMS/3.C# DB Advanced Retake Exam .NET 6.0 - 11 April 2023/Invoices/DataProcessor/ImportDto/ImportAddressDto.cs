using Invoices.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto;

[XmlType("Address")]
public class ImportAddressDto
{
    [XmlElement]
    [Required]
    [MinLength(ValidationConstants.AddressStreetNameMinLength)]
    [MaxLength(ValidationConstants.AddressStreetNameMaxLength)]
    public string StreetName { get; set; } = null!;

    [XmlElement]
    [Required]
    public int StreetNumber { get; set; }

    [XmlElement]
    [Required]
    public string PostCode { get; set; } = null!;

    [XmlElement]
    [Required]
    [MinLength(ValidationConstants.AddressCityMinLength)]
    [MaxLength(ValidationConstants.AddressCityMaxLength)]
    public string City { get; set; } = null!;

    [XmlElement]
    [Required]
    [MinLength(ValidationConstants.AddressCountryMinLength)]
    [MaxLength(ValidationConstants.AddressCountryMaxLength)]
    public string Country { get; set; } = null!;
}
