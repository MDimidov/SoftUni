using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models;

public class Product
{
    public Product()
    {
        CategoriesProducts = new HashSet<CategoryProduct>();
    }

    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    //ForeignKey(nameof(Seller))]
    public int SellerId { get; set; }
    public virtual User Seller { get; set; } = null!;


    public int? BuyerId { get; set; }
    public virtual User? Buyer { get; set; } = null!;

    public virtual ICollection<CategoryProduct> CategoriesProducts { get; set; }

}
