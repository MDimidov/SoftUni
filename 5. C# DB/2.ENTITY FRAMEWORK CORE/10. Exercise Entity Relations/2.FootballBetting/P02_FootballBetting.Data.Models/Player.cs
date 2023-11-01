using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Player
{
    public Player()
    {
        PlayersStatistics = new HashSet<PlayerStatistic>();
    }


    [Key]
    public int PlayerId { get; set; }

    [Required]
    [StringLength(ValidationConstants.PlayerNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public byte SquadNumber { get; set; } //Check for djudge

    [Required]
    [ForeignKey(nameof(Team))]
    public int TeamId { get; set; }
    public virtual Team Team { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Position))]
    public int PositionId { get; set; }
    public virtual Position Position { get; set; } = null!;

    [Required]
    public bool IsInjured { get; set; }

    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
}
