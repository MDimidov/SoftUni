using Footballers.Common;
using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models;

public class Team
{
    public Team()
    {
        TeamsFootballers = new HashSet<TeamFootballer>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(ValidationConstaints.TeamNameMaxLength)]

    public string Name { get; set; } = null!;

    [MaxLength(ValidationConstaints.TeamNationalityMaxLength)]
    public string Nationality { get; set; } = null!;

    public int Trophies { get; set; }

    public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }

}
