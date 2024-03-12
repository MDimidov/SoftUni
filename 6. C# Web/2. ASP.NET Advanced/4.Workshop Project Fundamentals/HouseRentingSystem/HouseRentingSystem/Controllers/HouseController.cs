using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.Infrastructure.Extensions;
using HouseRentingSystem.Web.ViewModels.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HouseRentingSystem.Common.NotificationMessageConstants;

namespace HouseRentingSystem.Web.Controllers;

[Authorize]
public class HouseController : Controller
{
	private readonly ICategoryService categoryService;
	private readonly IAgentService agentService;
	private readonly IHouseService houseService;

	public HouseController(
		ICategoryService categoryService,
		IAgentService agentService,
		IHouseService houseService)
	{
		this.categoryService = categoryService;
		this.agentService = agentService;
		this.houseService = houseService;
	}

	[AllowAnonymous]
	public async Task<IActionResult> All()
	{
		return View();
	}

	[HttpGet]
	public async Task<IActionResult> Add()
	{
		bool isAgent = await agentService.AgentExistByUserIdAsync(User.GetId()!);

		if(!isAgent)
		{
			this.TempData[ErrorMessage] = "You must become an agent in order to add new houses!";
			return RedirectToAction("Become", "Agent");
		}

		HouseFormModel model = new HouseFormModel()
		{
			Categories = await categoryService.AllCategoriesAsync()
		};

		return View(model);

	}

	[HttpPost]
	public async Task<IActionResult> Add(HouseFormModel model)
	{
		bool isAgent = await agentService.AgentExistByUserIdAsync(User.GetId()!);

		if (!isAgent)
		{
			this.TempData[ErrorMessage] = "You must become an agent in order to add new houses!";
			return RedirectToAction("Become", "Agent");
		}

		bool categoryExist = await categoryService.ExistByIdAsync(model.CategoryId);
		if(!categoryExist)
		{
			ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist");
		}

		if(!ModelState.IsValid)
		{
			model.Categories = await categoryService.AllCategoriesAsync();
			return View(model);
		}

		try
		{
			string? agentId = await agentService.GetAgentIdByUserIdAsync(User.GetId());
			await houseService.CreateAsync(model, agentId!);
		}
		catch
		{
			ModelState.AddModelError(string.Empty, "Unexpeted error occured while trying to save changes please try again later or contact with administrator!");
		}

		return RedirectToAction(nameof(All));
	}
}
