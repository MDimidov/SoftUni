namespace FastFood.Models;

using FastFood.Common.EntityConfig;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderItem
{
    [ForeignKey(nameof(Order))]
    [MaxLength(ValidationConstants.GuidMaxLength)]
    public string OrderId { get; set; } = null!;

    [Required]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey(nameof(Item))]
    [MaxLength(ValidationConstants.GuidMaxLength)]
    public string ItemId { get; set; } = null!;

    [Required]
    public virtual Item Item { get; set; } = null!;

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}