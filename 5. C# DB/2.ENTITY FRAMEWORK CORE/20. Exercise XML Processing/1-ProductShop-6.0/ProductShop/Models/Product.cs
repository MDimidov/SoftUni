namespace ProductShop.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    public Product()
    {
        this.CategoryProducts = new HashSet<CategoryProduct>();
    }

    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    [ForeignKey(nameof(User))]
    public int SellerId { get; set; }
    public virtual User Seller { get; set; } = null!;

    [ForeignKey(nameof(User))]
    public int? BuyerId { get; set; }
    public virtual User? Buyer { get; set; }

    public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
}