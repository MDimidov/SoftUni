using Library.Data;
using Library.Data.Models;
using Library.Models.Book;
using Library.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.Controllers;

[Authorize]
public class BookController : Controller
{
	private readonly LibraryDbContext dbContext;

	public BookController(LibraryDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	[HttpGet]
	public async Task<IActionResult> All()
	{
		var model = await dbContext
			.Books
			.AsNoTracking()
			.Select(b => new BookViewModel
			{
				Id = b.Id,
				Author = b.Author,
				Title = b.Title,
				Category = b.Category.Name,
				ImageUrl = b.ImageUrl,
				Rating = b.Rating,
			})
			.ToArrayAsync();

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> AddToCollection(int id)
	{
		var book = await dbContext
			.Books
			.Include(b => b.UsersBooks)
			.FirstOrDefaultAsync(b => b.Id == id);

		if (book == null)
		{
			return RedirectToAction(nameof(All));
		}

		string userId = GetUserId();
		var bookToAdd = new Data.Models.IdentityUserBook
		{
			Book = book,
			BookId = book.Id,
			CollectorId = userId
		};

		if (!book.UsersBooks.Any(up => up.CollectorId == userId && up.BookId == book.Id))
		{
			book.UsersBooks.Add(bookToAdd);

			await dbContext.SaveChangesAsync();
		}

		return RedirectToAction(nameof(All));
	}

	[HttpGet]
	public async Task<IActionResult> Mine()
	{
		var model = await dbContext
			.Books
			.AsNoTracking()
			.Where(b => b.UsersBooks.Any(ub => ub.CollectorId == GetUserId()))
			.Select(b => new BookViewModel
			{
				Id = b.Id,
				Author = b.Author,
				Title = b.Title,
				Category = b.Category.Name,
				ImageUrl = b.ImageUrl,
				Rating = b.Rating,
				Description = b.Description,
			})
			.ToArrayAsync();

		if(model == null)
		{
			return RedirectToAction(nameof(All));
		}

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> RemoveFromCollection(int id)
	{
		var book = await dbContext.Books.FindAsync(id);

		if (book == null)
		{
			return RedirectToAction(nameof(Mine));
		}

		var bookToDelete = await dbContext
			.IdentityUsersBooks
			.Where(ub => ub.CollectorId == GetUserId() && ub.BookId == id)
			.FirstOrDefaultAsync();

		if (bookToDelete == null)
		{
			return Unauthorized();
		}

		dbContext.IdentityUsersBooks.Remove(bookToDelete);
		await dbContext.SaveChangesAsync();

		return RedirectToAction(nameof(Mine));
	}

	private string GetUserId()
		=> User.FindFirstValue(ClaimTypes.NameIdentifier);

	[HttpGet]
	public async Task<IActionResult> Add()
	{
		if(!User?.Identity?.IsAuthenticated ?? true)
		{
			return Unauthorized();
		}

		var bookModel = new BookFormViewModel()
		{
			Categories = await GetCategoriesAsync()
		};

		return View(bookModel);
	}

	[HttpPost]
	public async Task<IActionResult> Add(BookFormViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

		var book = new Book()
		{
			Title = model.Title,
			Author = model.Author,
			Description = model.Description,
			CategoryId = model.CategoryId,
			ImageUrl = model.Url,
			Rating = model.Rating
		};

		await dbContext.Books.AddAsync(book);
		await dbContext.SaveChangesAsync();

		return RedirectToAction(nameof(All));
	}

	private async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
		=> await dbContext
				.Categories
				.AsNoTracking()
				.Select(c => new CategoryViewModel
				{
					Id = c.Id,
					Name = c.Name,
				})
				.ToArrayAsync();
}
