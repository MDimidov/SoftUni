using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Services.Data.Models.House;
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

	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> All([FromQuery]AllHousesQueryModel queryModel)
	{
		AllHousesFilteredAndPagedServiceModel serviceModel = await houseService.AllAsync(queryModel);

		queryModel.Houses = serviceModel.Houses;
		queryModel.TotalHouses = serviceModel.TotalHousesCount;
		queryModel.Categories = await categoryService.AllCategoryNamesAsync();

		return View(queryModel);
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

	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> Details(string id)
	{
		HouseDetailsViewModel? viewModel = await houseService
			.GetDetailsByIdAsync(id);

		if(viewModel == null)
		{
			TempData[ErrorMessage] = "House with the provided id does not exist!";
			return RedirectToAction(nameof(All));
		}

		return View(viewModel);
	}

	[HttpGet]
	public async Task<IActionResult> Mine()
	{
		List<HouseAllViewModel>  myHouses = new();

		string userId = User.GetId()!;

		bool isUserAgent = await agentService.AgentExistByUserIdAsync(userId);

		if(isUserAgent)
		{
			string? agentId = await agentService.GetAgentIdByUserIdAsync(userId);

			myHouses.AddRange(await houseService.AllByAgentIdAsync(agentId));
		}
		else
		{
			myHouses.AddRange(await houseService.AllByUserIdAsync(userId));
		}

		return View(myHouses);
	}
}
