using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.Infrastructure.Extensions;
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

	[HttpGet]
	public async Task<IActionResult> Details(int id, string information)
	{
		
		bool categoryExist = await categoryService.ExistByIdAsync(id);
		if(!categoryExist)
		{
			return NotFound();
		}
		CategoryDetailsViewModel viewModel = await categoryService.GetDetailsByIdAsync(id);

        if (viewModel.GetUrlInformation() != information)
		{
			return NotFound();
		}

		return View(viewModel);
	}
}
