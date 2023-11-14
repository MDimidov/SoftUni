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

    [MaxLength(ValidationConstraints.TeamNameMaxLength)]

    public string Name { get; set; } = null!;

    [MaxLength(ValidationConstraints.TeamNationalityMaxLength)]
    public string Nationality { get; set; } = null!;

    public int Trophies { get; set; }

    public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }

}
