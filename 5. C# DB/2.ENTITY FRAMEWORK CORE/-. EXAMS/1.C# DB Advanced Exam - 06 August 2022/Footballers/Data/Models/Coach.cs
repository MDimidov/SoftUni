using Footballers.Common;
using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models;

public class Coach
{
    public Coach()
    {
        Footballers = new HashSet<Footballer>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(ValidationConstaints.CooachNameMaxLength)]
    public string Name { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public virtual ICollection<Footballer> Footballers { get; set; }
}
