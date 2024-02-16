#nullable disable

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.ValidationConstants.Movie;
using static Watchlist.Common.ErrorMessages;


namespace Watchlist.Models.Movies;

public class MoviesAddFormModel
{
    public MoviesAddFormModel()
    {
        Genres = new HashSet<GenreViewModel>();
    }
    public int Id { get; set; }

    [Required(ErrorMessage = RequiredField)]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
        ErrorMessage = RequiredLength)]
    public string Title { get; set; }

    [Required(ErrorMessage = RequiredField)]
    [StringLength(DirectorMaxLength, MinimumLength = DirectorMinLength,
        ErrorMessage = RequiredLength)]
    public string Director { get; set; }

    [Required(ErrorMessage = RequiredField)]
    public string ImageUrl { get; set; }

    [Required(ErrorMessage = RequiredField)]
    [Range(RatingMinRange, RatingMaxRange, ErrorMessage = RequiredRange)]
    public decimal Rating { get; set; }

    public int GenreId { get; set; }

    public IEnumerable<GenreViewModel> Genres { get; set; }
}
