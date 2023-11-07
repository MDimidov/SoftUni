using CarDealer.Models;
using System.Text.Json.Serialization;

namespace CarDealer.DTOs.Import;

public class ImportCarDto
{
    public ImportCarDto()
    {
        PartsId = new HashSet<int>();
    }

    [JsonPropertyName("make")]
    public string Make { get; set; } = null!;

    [JsonPropertyName("model")]
    public string Model { get; set; } = null!;

    [JsonPropertyName("traveledDistance")]
    public long TravelledDistance { get; set; }

    [JsonPropertyName("partsId")]
    public IEnumerable<int> PartsId { get; set; }
}
