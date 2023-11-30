using SoftJail.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto;

public class ImportCellDto
{
    [Required]
    [Range(ValidationConstants.CellNumberMinRange, ValidationConstants.CellNumberMaxRange)]
    public int CellNumber { get; set; }

    [Required]
    public bool HasWindow { get; set; }
}
