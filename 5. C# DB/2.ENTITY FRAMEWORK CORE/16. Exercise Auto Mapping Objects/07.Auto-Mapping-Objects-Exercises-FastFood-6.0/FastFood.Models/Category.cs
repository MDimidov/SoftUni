namespace FastFood.Models;

using FastFood.Common.EntityConfig;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Category
{
    public Category()
    {
        Items = new HashSet<Item>();
    }
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(ValidationConstants.CategoryNameMaxLength, MinimumLength = 3)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; }
}
