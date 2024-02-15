#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Watchlist.Common.ValidationConstants.Movie;

namespace Watchlist.Data.Models;

public class Movie
{
    public Movie()
    {
        UsersMovies = new HashSet<UserMovie>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; }

    [Required]
    [MaxLength(DirectorMaxLength)]
    public string Director { get; set; }

    [Required]
    public string ImageUrl { get; set; }

    [Required]
    public decimal Rating { get; set; }


    [Required]
    [ForeignKey(nameof(Genre))]
    public int GenreId { get; set; }

    public virtual Genre Genre { get; set; }


    public virtual ICollection<UserMovie> UsersMovies { get; set; }
}

//• Has Id – a unique integer, Primary Key
//• Has Title – a string with min length 10 and max length 50 (required)
//• Has Director – a string with min length 5 and max length 50 (required)
//• Has ImageUrl – a string (required)
//• Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
//• Has GenreId – an integer(required)
//• Has Genre – a Genre(required)
//• Has UsersMovies – a collection of type UserMovie