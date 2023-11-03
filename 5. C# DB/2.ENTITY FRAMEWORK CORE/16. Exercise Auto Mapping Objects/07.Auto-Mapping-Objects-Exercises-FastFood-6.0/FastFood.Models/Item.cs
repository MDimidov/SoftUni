namespace FastFood.Models;

using FastFood.Common.EntityConfig;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Item
{
    public Item()
    {
        Id = Guid.NewGuid().ToString();
        OrderItems = new HashSet<OrderItem>();
    }

    [Key]
    [MaxLength(ValidationConstants.GuidMaxLength)]
    public string Id { get; set; }

    [MaxLength(ValidationConstants.ItemNameMaxLength)]
    public string? Name { get; set; }

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    [Required]
    public virtual Category Category { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
}