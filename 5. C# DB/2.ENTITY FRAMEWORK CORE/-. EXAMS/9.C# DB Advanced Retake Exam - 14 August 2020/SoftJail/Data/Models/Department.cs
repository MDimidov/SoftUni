using SoftJail.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models;

public class Department
{
    public Department()
    {
        Cells = new HashSet<Cell>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.DepartmentNameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Cell> Cells { get; set; }
}
