using System.Text.Json.Serialization;

namespace CarDealer.DTOs.Import;

public class ImportCustomerDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("birthDate")]
    public DateTime BirthDate { get; set; }

    [JsonPropertyName("isYoungDriver")]
    public bool IsYoungDriver { get; set; }
}
