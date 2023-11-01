namespace FastFood.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Enums;
using FastFood.Common.EntityConfig;

public class Order
{
    public Order()
    {
        Id = Guid.NewGuid().ToString();
        OrderItems = new HashSet<OrderItem>();
    }

    [Key]
    [MaxLength(ValidationConstants.GuidMaxLength)]
    public string Id { get; set; }

    [Required]
    public string Customer { get; set; } = null!;

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public OrderType Type { get; set; }

    [NotMapped]
    public decimal TotalPrice { get; set; }

    [ForeignKey(nameof(Employee))]
    [MaxLength(ValidationConstants.GuidMaxLength)]
    public string EmployeeId { get; set; } = null!;

    [Required]
    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; }
}