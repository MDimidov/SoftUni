#nullable disable

using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.ValidationConstants.Category;

namespace SoftUniBazar.Data.Models;
public class Category
{
    public Category()
    {
        Ads = new HashSet<Ad>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; }

    public virtual ICollection<Ad> Ads { get; set; }
}

//• Has Id – a unique integer, Primary Key
//• Has Name – a string with min length 3 and max length 15 (required)
//• Has Ads – a collection of type Ad