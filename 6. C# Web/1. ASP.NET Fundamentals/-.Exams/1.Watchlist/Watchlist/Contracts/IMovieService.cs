using Watchlist.Data.Models;
using Watchlist.Models.Movies;

namespace Watchlist.Contracts;

public interface IMovieService
{
    Task<IEnumerable<MoviesAllViewModel>> GetAllAsync();

    Task<IEnumerable<GenreViewModel>> GetGenresAsync();

    Task AddMovieAsync(MoviesAddFormModel model);

    Task AddToCollection(int id, string userId);

    Task <IEnumerable<MoviesAllViewModel>> GetWatchedAsync(string userId);

    Task RemoveFromWatchedAsync(int movieId, string userId);
}
