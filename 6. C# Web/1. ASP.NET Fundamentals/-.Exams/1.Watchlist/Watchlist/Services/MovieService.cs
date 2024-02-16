using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models.Movies;

namespace Watchlist.Services;

public class MovieService : IMovieService
{
    private readonly WatchlistDbContext dbContext;

    public MovieService(WatchlistDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddMovieAsync(MoviesAddFormModel model)
    {
        var entity = new Movie()
        {
            Director = model.Director,
            Title = model.Title,
            GenreId = model.GenreId,
            ImageUrl = model.ImageUrl,
            Rating = model.Rating,
        };

        await dbContext.Movies.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddToCollection(int movieId, string userId)
    {
        var user = await dbContext.Users.FindAsync(userId);
        if (user == null)
        {
            throw new ArgumentException("Invalid user ID");
        }

        var movie = await dbContext.Movies.FindAsync(movieId);
        if (movie == null)
        {
            throw new ArgumentException("Invalid movie ID");
        }

        var userM = await dbContext.UsersMovies
            .Where(um => um.MovieId == movieId && um.UserId == userId)
            .FirstOrDefaultAsync();

        if (userM == null)
        {
            var userMovie = new UserMovie()
            {
                MovieId = movieId,
                UserId = userId,
                User = user,
                Movie = movie
            };

            user.UsersMovies.Add(userMovie);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<MoviesAllViewModel>> GetAllAsync()
    {
        var entities = await dbContext
            .Movies
            .Include(m => m.Genre)
            .AsNoTracking()
            .ToArrayAsync();

        return entities
            .Select(m => new MoviesAllViewModel()
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director,
                Genre = m.Genre?.Name,
                Rating = m.Rating,
                ImageUrl = m.ImageUrl
            });
    }

    public async Task<IEnumerable<GenreViewModel>> GetGenresAsync()
        => await dbContext
        .Genres
        .AsNoTracking()
        .Select(g => new GenreViewModel()
        {
            Id = g.Id,
            Name = g.Name,
        })
        .ToArrayAsync();

    public async Task<IEnumerable<MoviesAllViewModel>> GetWatchedAsync(string userId)
    {
        var watchedMovies = await dbContext
            .Movies
            .Include(m => m.Genre)
            .AsNoTracking()
            .Where(m => m.UsersMovies.Any(mu => mu.UserId == userId))
            .ToArrayAsync();

        return watchedMovies
            .Select(m => new MoviesAllViewModel()
            {
                Id = m.Id,
                Director = m.Director,
                Genre = m?.Genre?.Name,
                ImageUrl = m.ImageUrl,
                Rating = m.Rating,
                Title = m.Title,
            });
    }

    public async Task RemoveFromWatchedAsync(int movieId, string userId)
    {
        var userMovie = await dbContext
            .UsersMovies
            .Where(m => m.MovieId == movieId && m.UserId == userId)
            .FirstOrDefaultAsync();

        if(userMovie == null)
        {
            throw new ArgumentNullException("This movie is not in user watchlist");
        }

        dbContext.UsersMovies.Remove(userMovie);
        await dbContext.SaveChangesAsync();
    }
}
