#nullable disable

using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.ValidationConstants.Genre;

namespace Watchlist.Data.Models;

public class Genre
{
    public Genre()
    {
        Movies = new HashSet<Movie>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; }

    public virtual ICollection<Movie> Movies { get; set; }
}


//• Has Id – a unique integer, Primary Key
//• Has Name – a string with min length 5 and max length 50 (required)
//• Has Movies – a collection of Movie
