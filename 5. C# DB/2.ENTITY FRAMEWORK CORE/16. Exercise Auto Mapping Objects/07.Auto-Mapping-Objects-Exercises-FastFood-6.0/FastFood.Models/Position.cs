namespace FastFood.Models;

using FastFood.Common.EntityConfig;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Position
{
    public Position()
    {
        Employees = new HashSet<Employee>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.PositionNameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; }
}