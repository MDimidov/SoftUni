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

	public HouseController(
		ICategoryService categoryService,
		IAgentService agentService)
	{
		this.categoryService = categoryService;
		this.agentService = agentService;
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
}
