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
	public async Task<IActionResult> All([FromQuery] AllHousesQueryModel queryModel)
	{
		try
		{
			AllHousesFilteredAndPagedServiceModel serviceModel = await houseService.AllAsync(queryModel);

			queryModel.Houses = serviceModel.Houses;
			queryModel.TotalHouses = serviceModel.TotalHousesCount;
			queryModel.Categories = await categoryService.AllCategoryNamesAsync();

			return View(queryModel);
		}
		catch
		{
			return GeneralError();
		}
	}

	[HttpGet]
	public async Task<IActionResult> Add()
	{
		bool isAgent = await agentService.AgentExistByUserIdAsync(User.GetId()!);

		if (!isAgent)
		{
			this.TempData[ErrorMessage] = "You must become an agent in order to add new houses!";
			return RedirectToAction("Become", "Agent");
		}

		try
		{
			HouseFormModel model = new HouseFormModel()
			{
				Categories = await categoryService.AllCategoriesAsync()
			};

			return View(model);
		}
		catch
		{
			return GeneralError();
		}

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
		if (!categoryExist)
		{
			ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist");
		}

		if (!ModelState.IsValid)
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

		bool houseExist = await houseService.ExistByIdAsync(id);
		if (!houseExist)
		{
			TempData[ErrorMessage] = "House with the provided id does not exist!";
			return RedirectToAction(nameof(All));
		}

		try
		{
			HouseDetailsViewModel viewModel = await houseService
			.GetDetailsByIdAsync(id);

			return View(viewModel);
		}
		catch
		{
			return GeneralError();
		}
	}

	[HttpGet]
	public async Task<IActionResult> Mine()
	{
		List<HouseAllViewModel> myHouses = new();

		string userId = User.GetId()!;

		bool isUserAgent = await agentService.AgentExistByUserIdAsync(userId);

		try
		{
			if (isUserAgent)
			{
				string? agentId = await agentService.GetAgentIdByUserIdAsync(userId);

				myHouses.AddRange(await houseService.AllByAgentIdAsync(agentId));
			}
			else
			{
				myHouses.AddRange(await houseService.AllByUserIdAsync(userId));
			}
		}
		catch
		{
			return GeneralError();
		}

		return View(myHouses);
	}

	[HttpGet]
	public async Task<IActionResult> Edit(string id) 
	{
		bool houseExist = await houseService.ExistByIdAsync(id);
		if (!houseExist)
		{
			TempData[ErrorMessage] = "House with the provided id does not exist!";
			return RedirectToAction(nameof(All));
		}

		bool isUserAgent = await agentService.AgentExistByUserIdAsync(User.GetId()!);
		if (!isUserAgent)
		{
			TempData[ErrorMessage] = "You must become an agent in order to edit house info!";
			return RedirectToAction("Become", "Agent");
		}

		string agentId = await agentService.GetAgentIdByUserIdAsync(User.GetId()!);

		bool isAgentOwner = await houseService.IsAgentWithIdOwnerOfHouseWithIdAsync(agentId, id);
		if (!isAgentOwner)
		{
			TempData[ErrorMessage] = "You must become the agent owner of the house you want to edit!";
			return RedirectToAction(nameof(Mine));
		}

		try
		{
			HouseFormModel formModel = await houseService.GetHouseForEditByIdAsync(id);
			formModel.Categories = await categoryService.AllCategoriesAsync();

			return View(formModel);
		}
		catch
		{
			return GeneralError();
		}		
	}

	[HttpPost]
	public async Task<IActionResult> Edit(string id, HouseFormModel model)
	{
		if (!ModelState.IsValid)
		{
			model.Categories = await categoryService.AllCategoriesAsync();
			return View(model);
		}

		bool houseExist = await houseService.ExistByIdAsync(id);
		if (!houseExist)
		{
			TempData[ErrorMessage] = "House with the provided id does not exist!";
			return RedirectToAction(nameof(All));
		}

		bool isUserAgent = await agentService.AgentExistByUserIdAsync(User.GetId()!);
		if (!isUserAgent)
		{
			TempData[ErrorMessage] = "You must become an agent in order to edit house info!";
			return RedirectToAction("Become", "Agent");
		}

		string agentId = await agentService.GetAgentIdByUserIdAsync(User.GetId()!);

		bool isAgentOwner = await houseService.IsAgentWithIdOwnerOfHouseWithIdAsync(agentId, id);
		if (!isAgentOwner)
		{
			TempData[ErrorMessage] = "You must become the agent owner of the house you want to edit!";
			return RedirectToAction(nameof(Mine));
		}

		try
		{
			await houseService.EditHouseByIdAndFormModelAsync(id, model);
		}
		catch
		{
			ModelState.AddModelError(string.Empty, "Unexpectet error occured while trying to update the house. Please try again later or contact with administrator!");
			model.Categories = await categoryService.AllCategoriesAsync();
			return View(model);
		}

		return RedirectToAction(nameof(Details), new { id });
	}


	private IActionResult GeneralError()
	{
		TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact with administrator!";

		return RedirectToAction("Index", "Home");
	}
}
