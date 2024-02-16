using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Contracts;
using Watchlist.Data.Models;
using Watchlist.Models.Movies;

namespace Watchlist.Controllers;

[Authorize]
public class MoviesController : Controller
{
    private readonly IMovieService movieService;

    public MoviesController(IMovieService movieService)
    {
        this.movieService = movieService;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var model = await movieService.GetAllAsync();

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new MoviesAddFormModel()
        {
            Genres = await movieService.GetGenresAsync()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(MoviesAddFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await movieService.AddMovieAsync(model);

            return RedirectToAction(nameof(All));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);

            return View(model);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddToCollection(int id)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(All));
        }

        try
        {
            await movieService.AddToCollection(id, GetUserId());
        }
        catch(Exception)
        {
            throw;
        }
        return RedirectToAction(nameof(Watched));
    }

    public async Task<IActionResult> Watched()
    {
        string userId = GetUserId();

        var model = await movieService.GetWatchedAsync(userId);

        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> RemoveFromCollection(int id)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Watched));
        }

        try
        {
            await movieService.RemoveFromWatchedAsync(id,  GetUserId());
        }
        catch
        {
            return RedirectToAction(nameof(Watched));
        }

        return RedirectToAction(nameof(All));
    }

    private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);
}
