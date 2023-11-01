using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_FootballBetting.Data.Common;

namespace P02_FootballBetting.Data.Models;

public class Team
{
    public Team()
    {
        HomeGames = new HashSet<Game>();
        AwayGames = new HashSet<Game>();
        Players = new HashSet<Player>();
    }


    [Key] 
    public int TeamId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.TeamNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.TeamLogoUrlMaxLength)]
    public string LogoUrl { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.TeamInitialsMaxLength)]
    public string Initials { get; set; } = null!;

    [Required]
    public decimal Budget {  get; set; }

    [Required]
    public int PrimaryKitColorId { get; set;}
    public virtual Color PrimaryKitColor { get; set; } = null!;


    [Required]
    public int SecondaryKitColorId { get; set;}
    public virtual Color SecondaryKitColor { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Town))]
    public int TownId { get;set;}

    public virtual Town Town { get; set; } = null!;

    public virtual ICollection<Game> HomeGames { get; set; }
    public virtual ICollection<Game> AwayGames { get; set; }

    public virtual ICollection<Player> Players { get; set; }


}