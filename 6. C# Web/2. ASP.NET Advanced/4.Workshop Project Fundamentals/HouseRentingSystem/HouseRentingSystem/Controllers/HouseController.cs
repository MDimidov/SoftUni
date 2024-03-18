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
			string agentId = await agentService.GetAgentIdByUserIdAsync(User.GetId()!);
			string houseId = await houseService.CreateAndReturnIdAsync(model, agentId);

			TempData[SuccessMessage] = "House was added successfully.";

			return RedirectToAction(nameof(Details), new { id = houseId });
		}
		catch
		{
			ModelState.AddModelError(string.Empty, "Unexpeted error occured while trying to save changes please try again later or contact with administrator!");
			return View(model);
		}
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

		TempData[SuccessMessage] = "House was added successfully.";
		return RedirectToAction(nameof(Details), new { id });
	}

	[HttpGet]
	public async Task<IActionResult> Delete(string id)
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
			HousePreDeleteDetailsViewModel deleteModel = await houseService.GetHouseForDeleteByIdAsync(id);

			return View(deleteModel);
		}
		catch
		{
			return GeneralError();
		}
	}

	[HttpPost]
	public async Task<IActionResult> Delete(string id, HousePreDeleteDetailsViewModel model)
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
			await houseService.DeleteHouseByIdAsync(id);

			TempData[WarningMessage] = "The House was succesfully delete!";
			return RedirectToAction(nameof(Mine));
		}
		catch
		{
			return GeneralError();
		}
	}

	[HttpPost]
	public async Task<IActionResult> Rent(string id)
	{
		bool houseExists = await houseService.ExistByIdAsync(id);
		if(!houseExists)
		{
			TempData[ErrorMessage] = "House with provided Id does not exist! Please try again.";

			return RedirectToAction(nameof(All));
		}

		bool isHouseRented = await houseService.IsRentedByIdAsync(id);
		if(isHouseRented)
		{
			TempData[ErrorMessage] = "Selected house is already rented by another user, please select another house";

			return RedirectToAction(nameof(All));
		}

		bool isUserAgent = await agentService.AgentExistByUserIdAsync(User.GetId()!);
		if(isUserAgent)
		{
			TempData[ErrorMessage] = "Agents can't rent a houses. Please register as a user.";

			return RedirectToAction("Index", "Home");
		}

		try
		{
			await houseService.RentHouseAsync(id, User.GetId()!);

			TempData[SuccessMessage] = "You rent a house succesfully.";
		}
		catch
		{
			return GeneralError();
		}

		return RedirectToAction(nameof(Mine));
	}


	[HttpPost]
	public async Task<IActionResult> Leave(string id)
	{
		bool houseExists = await houseService.ExistByIdAsync(id);
		if (!houseExists)
		{
			TempData[ErrorMessage] = "House with provided Id does not exist! Please try again.";

			return RedirectToAction(nameof(All));
		}

		bool isHouseRented = await houseService.IsRentedByIdAsync(id);
		if (!isHouseRented)
		{
			TempData[ErrorMessage] = "Selected house is not rented! Please select another house if you wish to leave it";

			return RedirectToAction(nameof(Mine));
		}

		bool isCurrentUserRenterOfTheHouse = await houseService.IsRentedByUserWithIdAsync(id, User.GetId()!);
		if (!isCurrentUserRenterOfTheHouse)
		{
			TempData[ErrorMessage] = "You must be renter of the house in order to leave it! Please try again with one of your rented house if you wish to leave it!";

			return RedirectToAction(nameof(Mine));
		}

		try
		{
			await houseService.LeaveHouseAsync(id);

			TempData[SuccessMessage] = "You succefuly leave this house!";
		}
		catch
		{
			return GeneralError();
		}

		return RedirectToAction(nameof(Mine));
	}
	private IActionResult GeneralError()
	{
		TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact with administrator!";

		return RedirectToAction("Index", "Home");
	}
}
