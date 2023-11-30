using SoftJail.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto;

public class ImportDepartmentDto
{
    [Required]
    [MinLength(ValidationConstants.DepartmentNameMinLength)]
    [MaxLength(ValidationConstants.DepartmentNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public ImportCellDto[] Cells { get; set; } = null!;
}
