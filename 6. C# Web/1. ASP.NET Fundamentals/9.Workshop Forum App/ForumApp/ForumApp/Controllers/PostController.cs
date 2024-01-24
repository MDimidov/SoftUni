using Forum.Data;
using Forum.Data.Models;
using Forum.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forum.App.Controllers;

public class PostController : Controller
{
	private readonly ForumDbContext dbContext;

	public PostController(ForumDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	//public IActionResult Index()
	//{
	//	return View();
	//}

	public async Task<IActionResult> All()
	{
		var posts = await dbContext
			.Posts
			.AsNoTracking()
			.Select(p => new PostViewModel()
			{
				Id = p.PostId.ToString(),
				Title = p.Title,
				Content = p.Content,
			})
			.ToListAsync();

		return View(posts);
	}

	[HttpGet]
	public async Task<IActionResult> Add()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Add(PostFormViewModel model)
	{
		var post = new Post()
		{
			Title = model.Title,
			Content = model.Content,
		};

		await dbContext.Posts.AddAsync(post);
		await dbContext.SaveChangesAsync();

		return RedirectToAction("All");
	}

	[HttpGet]
	public async Task<IActionResult> Edit(string id)
	{
		Post? model = await dbContext
			.Posts
			.FirstOrDefaultAsync(p => p.PostId.ToString() == id);

		if(model == null)
		{
			return RedirectToAction("All");
		}
		else
		{
			return View(new PostFormViewModel()
			{
				Title = model.Title,
				Content = model.Content,
			});
		}	
	}

	[HttpPost]
	public async Task<IActionResult> Edit(string id, PostFormViewModel model)
	{
		var post = await dbContext
			.Posts
			.FirstOrDefaultAsync(p => p.PostId.ToString().Equals(id));

		if (post == null)
		{
			return RedirectToAction("All");
		}

		post.Title = model.Title;
		post.Content = model.Content;

		await dbContext.SaveChangesAsync();

		return RedirectToAction("All");
	}

	[HttpPost]
	public async Task<IActionResult> Delete(string id)
	{
		Post? model = await dbContext
			.Posts
			.FirstOrDefaultAsync(p => p.PostId.ToString().Equals(id));

		if(model == null)
		{
			return RedirectToAction("All");
		}

		dbContext.Posts.Remove(model);
		await dbContext.SaveChangesAsync();

		return RedirectToAction("All");
	}
}
