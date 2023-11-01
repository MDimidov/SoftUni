using System.ComponentModel.DataAnnotations;

using P02_FootballBetting.Data.Common;

namespace P02_FootballBetting.Data.Models;

public class Color
{
    public Color() 
    {
        PrimaryKitTeams = new HashSet<Team>();
        SecondaryKitTeams = new HashSet<Team>();
    }

    [Key] 
    public int ColorId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ColorNameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Team> PrimaryKitTeams { get; set;}

    public virtual ICollection<Team> SecondaryKitTeams { get; set; }
}
