using MusicHub.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;

public class Performer
{
    public Performer()
    {
        PerformerSongs = new HashSet<SongPerformer>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstraints.PerformerFirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstraints.PerformerLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [Required]
    public int Age { get; set; }

    [Required]
    public decimal NetWorth { get; set; }

    public virtual ICollection<SongPerformer> PerformerSongs { get; set; }

}
