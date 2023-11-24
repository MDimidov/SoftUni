using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.DataProcessor.ImportDto;

public class ImportGameDto
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string ReleaseDate { get; set; } = null!;

    [Required]
    public string Developer { get; set; } = null!;

    [Required]
    public string Genre { get; set; } = null!;

    [Required]
    public string[] Tags { get; set; } = null!;
}
