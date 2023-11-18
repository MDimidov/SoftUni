using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto;

public class ImportCountryIdDto
{
    [Required]
    public int Id { get; set; } 
}
