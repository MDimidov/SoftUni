using CarDealer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarDealer.DTOs.Import;

public class ImportSaleDto
{
    [JsonPropertyName("carId")]
    public int CarId { get; set; }

    [JsonPropertyName("customerId")]
    public int CustomerId { get; set; }

    [JsonPropertyName("discount")]
    public decimal Discount { get; set; }
}
