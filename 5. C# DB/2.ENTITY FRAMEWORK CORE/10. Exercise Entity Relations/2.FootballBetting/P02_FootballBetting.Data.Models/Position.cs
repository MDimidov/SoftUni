using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;

public class Position
{
    public Position()
    {
        Players = new HashSet<Player>();
    }


    [Key]
    public int PositionId { get; set; }

    [Required]
    [StringLength(ValidationConstants.PositionNameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = null!;
}
