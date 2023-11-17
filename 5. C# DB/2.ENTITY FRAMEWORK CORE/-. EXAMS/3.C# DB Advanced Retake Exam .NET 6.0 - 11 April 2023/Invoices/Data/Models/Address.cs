using Invoices.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models;

public class Address
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.AddressStreetNameMaxLength)]
    public string StreetName { get; set; } = null!;

    public int StreetNumber { get; set; }

    [Required]
    public string PostCode { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.AddressCityMaxLength)]
    public string City { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.AddressCountryMaxLength)]
    public string Country { get; set; } = null!;


    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
