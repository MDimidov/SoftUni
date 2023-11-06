using System.Text.Json.Serialization;

namespace CarDealer.DTOs.Import;

public class ImportPartDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("supplierId")]
    public int SupplierId {  get; set; }
}
