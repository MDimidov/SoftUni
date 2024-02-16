#nullable disable

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.ValidationConstants.Movie;
using static Watchlist.Common.ErrorMessages;

namespace Watchlist.Models.Movies;

public class MoviesAllViewModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Director { get; set; }

    public string ImageUrl { get; set; }

    public decimal Rating { get; set; }

    public string Genre { get; set; }
}
