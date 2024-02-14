#nullable disable

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SoftUniBazar.Common.ValidationConstants.Ad;

namespace SoftUniBazar.Data.Models;
public class Ad
{
    public Ad()
    {
        AdsBuyers = new HashSet<AdBuyer>();
    }
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; }

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    [ForeignKey(nameof(Owner))]
    public string OwnerId { get; set; }

    public virtual IdentityUser Owner { get; set; }

    [Required]
    public string ImageUrl { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<AdBuyer> AdsBuyers { get; set; }
}


