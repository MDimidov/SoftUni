using Artillery.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models;

public class Manufacturer
{
    public Manufacturer()
    {
        Guns = new HashSet<Gun>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ManufacturerNameMaxLength)]
    public string ManufacturerName { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.ManufacturerFoundedMaxLength)]
    public string Founded { get; set; } = null!;

    public virtual ICollection<Gun> Guns { get; set; }
}
