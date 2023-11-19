using System.ComponentModel.DataAnnotations;
using Theatre.Common;

namespace Theatre.Data.Models;

public class Theatre
{
    public Theatre()
    {
        Tickets = new HashSet<Ticket>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.TheatreNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public sbyte NumberOfHalls { get; set; }

    [Required]
    [MaxLength(ValidationConstants.TheatreDirectorMaxLength)]
    public string Director { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets  { get; set; }
}
