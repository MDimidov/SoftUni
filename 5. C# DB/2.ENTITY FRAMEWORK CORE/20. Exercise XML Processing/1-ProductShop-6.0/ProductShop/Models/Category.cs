namespace ProductShop.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Category
{
    public Category()
    {
        this.CategoryProducts = new HashSet<CategoryProduct>();
    }

    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
}
