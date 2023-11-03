namespace FastFood.Models;

using FastFood.Common.EntityConfig;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    public Employee()
    {
        this.Id = Guid.NewGuid().ToString();
        Orders = new HashSet<Order>();
    }

    [Key]
    [MaxLength(ValidationConstants.GuidMaxLength)]
    public string Id { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.EmployeeNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [Range(15, 80)]
    public int Age { get; set; }

    [Required]
    [MaxLength(ValidationConstants.EmployeeAddressMaxLength)]
    public string Address { get; set; } = null!;

    [ForeignKey(nameof(Position))]
    public int PositionId { get; set; }

    [Required]
    public virtual Position Position { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; }
}