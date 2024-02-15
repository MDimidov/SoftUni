#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watchlist.Data.Models;

public class UserMovie
{
    [Required]
    [ForeignKey(nameof(User))]
    public string UserId { get; set; }

    public virtual User User { get; set; }


    [Required]
    [ForeignKey(nameof(Movie))]
    public int MovieId { get; set; }
    public virtual Movie Movie { get; set;}
}

//• UserId – a string, Primary Key, foreign key(required)
//• User – User
//• MovieId – an integer, Primary Key, foreign key(required)
//• Movie – Movie
