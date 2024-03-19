using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Web.Controllers;

[Authorize]
public class CategoryController : Controller
{
	private readonly ICategoryService categoryService;
	public CategoryController(ICategoryService categoryService) 
	{
		this.categoryService = categoryService;
	}

	[HttpGet]
	public async Task<IActionResult> All ()
	{
		IEnumerable<AllCategoriesViewModel> viewModel = 
			await categoryService.AllCategoriesForListAsync();

		return View(viewModel);
	}
}
