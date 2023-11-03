using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models;

public class Category
{
    public Category()
    {
        CategoriesProducts = new HashSet<CategoryProduct>();
    }

    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CategoryProduct> CategoriesProducts { get; set; }
}
