using Forum.Services.Interfaces;
using Forum.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;

namespace Forum.App.Controllers;

public class PostController : Controller
{
	private readonly IPostService postService;

	public PostController(IPostService postService)
	{
		this.postService = postService;
	}

	//public IActionResult Index()
	//{
	//	return View();
	//}

	public async Task<IActionResult> All()
	{
		IEnumerable<PostViewModel> posts = await postService.ListAllAsync();

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
		await postService.AddPostAsync(model);

		return RedirectToAction("All");
	}

	[HttpGet]
	public async Task<IActionResult> Edit(string id)
	{
		try
		{
			PostFormViewModel postFormModel = await postService.GetForEditOrDeleteByIdAsync(id);
			return View(postFormModel);
		}
		catch (Exception)
		{
			return RedirectToAction("All", "Post");
		}
	}

	[HttpPost]
	public async Task<IActionResult> Edit(string id, PostFormViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return this.View(model);
		}

		try
		{
			await postService.EditPostAsync(id, model);

		}
		catch
		{
			ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating your post!");

			return RedirectToAction("All");
		}

		return RedirectToAction("All", "Post");
	}

	[HttpPost]
	public async Task<IActionResult> Delete(string id)
	{
		await postService.DeletePostAsync(id);

		return RedirectToAction("All");
	}
}
