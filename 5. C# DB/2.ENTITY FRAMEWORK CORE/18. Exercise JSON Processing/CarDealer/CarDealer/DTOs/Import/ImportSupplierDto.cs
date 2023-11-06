using System.Text.Json.Serialization;

namespace CarDealer.DTOs.Import;

public class ImportSupplierDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("isImporter")]
    public bool IsImporter { get; set; }
}
