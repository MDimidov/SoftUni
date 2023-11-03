using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models;

public class User
{
    public User()
    {
        SoldProducts = new HashSet<Product>();
        BoughtProducts = new HashSet<Product>();
    }

    [Key] 
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public int? Age { get; set; }

    public virtual ICollection<Product> SoldProducts { get; set; }
    public virtual ICollection<Product> BoughtProducts { get; set; }
}
