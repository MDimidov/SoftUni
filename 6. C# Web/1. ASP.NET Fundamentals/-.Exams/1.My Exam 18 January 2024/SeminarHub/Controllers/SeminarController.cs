using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models.Category;
using SeminarHub.Models.Seminar;
using System.Globalization;
using System.Security.Claims;
using static SeminarHub.Common.ValidationConstants.Seminar;
using static SeminarHub.Common.ErrorMessages;


namespace SeminarHub.Controllers;

[Authorize]
public class SeminarController : Controller
{
	private readonly SeminarHubDbContext dbContext;

	public SeminarController(SeminarHubDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	
	[HttpGet]
	public async Task<IActionResult> All()
	{
		//Create view model with needed properties 
		var model = await dbContext.Seminars
			.AsNoTracking()
			.Select(s => new SeminarViewModel(
				s.Id,
				s.Topic,
				s.Lecturer,
				s.Organizer.UserName,
				s.DateAndTime,
				s.Category.Name))
			.ToArrayAsync();

		return View(model);
	}

	[HttpGet]
	public async Task<IActionResult> Add()
	{
		//Create list for drop down menu for categories
		var model = new SeminarFormViewModel()
		{
			Categories = await GetCategoriesAsync()
		};

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Add(SeminarFormViewModel model)
	{
		//Check if DateTime Format is valid
		if (!DateTime.TryParseExact(model.DateAndTime,
			DateAndTimeFormat, CultureInfo.InvariantCulture,
			DateTimeStyles.None, out DateTime dateAndTime))
		{
			ModelState.AddModelError(nameof(model.DateAndTime), WrongDateTimeFormat);
		}

		//If DateTime format is not valid return the same page
		if (!ModelState.IsValid)
		{
			model.Categories = await GetCategoriesAsync();
			return View(model);
		}

		//Create new Seminar with filled values
		var seminar = new Seminar()
		{
			Topic = model.Topic,
			Lecturer = model.Lecturer,
			Details = model.Details,
			CategoryId = model.CategoryId,
			Duration = model.Duration,
			OrganizerId = GetUserId(),
			DateAndTime = dateAndTime
		};

		//Save Seminar in DataBase
		await dbContext.Seminars.AddAsync(seminar);
		await dbContext.SaveChangesAsync();

		//Return page with all Seminars
		return RedirectToAction(nameof(All));
	}

	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
		var seminar = await dbContext.Seminars.FindAsync(id);

		//Check if the seminar exist
		if (seminar == null)
		{
			return BadRequest();
		}

		string userId = GetUserId();

		//Check the authorization of the user
		if (seminar.OrganizerId != userId)
		{
			return Unauthorized();
		}

		//Show page edit with last values for the fields
		var model = new SeminarFormViewModel()
		{
			Topic = seminar.Topic,
			Details = seminar.Details,
			Lecturer = seminar.Lecturer,
			DateAndTime = seminar.DateAndTime.ToString(DateAndTimeFormat, CultureInfo.InvariantCulture),
			Categories = await GetCategoriesAsync(),
			CategoryId = seminar.CategoryId,
			Duration = seminar.Duration,
		};

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(SeminarFormViewModel model, int id)
	{
		var seminar = await dbContext.Seminars.FindAsync(id);

		//Check if the seminar exist
		if (seminar == null)
		{
			return BadRequest();
		}

		string userId = GetUserId();

		//Check the authorization of the user
		if (seminar.OrganizerId != userId)
		{
			return Unauthorized();
		}

		if (!DateTime.TryParseExact(model.DateAndTime,
			DateAndTimeFormat, CultureInfo.InvariantCulture,
			DateTimeStyles.None, out DateTime dateAndTime))
		{
			ModelState.AddModelError(nameof(model.DateAndTime), WrongDateTimeFormat);
		}

		if (!ModelState.IsValid)
		{
			model.Categories = await GetCategoriesAsync();
			return View(model);
		}

		//Change the values of the properties
		seminar.Topic = model.Topic;
		seminar.Lecturer = model.Lecturer;
		seminar.Details = model.Details;
		seminar.DateAndTime = dateAndTime;
		seminar.Duration = model.Duration;
		seminar.CategoryId = model.CategoryId;

		//Save new changes in DataBase
		await dbContext.SaveChangesAsync();

		//Return page with all Seminars
		return RedirectToAction(nameof(All));
	}

	public async Task<IActionResult> Join(int id)
	{
		var seminar = await dbContext
			.Seminars
			.Include(s => s.SeminarsParticipants)
			.Where(s => s.Id == id)
			.FirstOrDefaultAsync();

		//Check if the seminar exist
		if (seminar == null)
		{
			return BadRequest();
		}

		string userId = GetUserId();

		//Check if the seminarParticipants exist 
		if (seminar.SeminarsParticipants.Any(sp => sp.ParticipantId == userId))
		{
			return RedirectToAction(nameof(All));
		}

		//Create new SeminarParticipant
		var seminarParticipant = new SeminarParticipant()
		{
			SeminarId = seminar.Id,
			ParticipantId = userId
		};

		//Add the seminar into Joined Seminars
		seminar.SeminarsParticipants.Add(seminarParticipant);
		await dbContext.SaveChangesAsync();

		return RedirectToAction(nameof(Joined));
	}

	[HttpGet]
	public async Task<IActionResult> Joined()
	{
		//Get only the Seminars that the user is joined
		var model = await dbContext.Seminars
			.AsNoTracking()
			.Where(s => s.SeminarsParticipants
					.Any(sp => sp.ParticipantId == GetUserId()))
			.Select(s => new SeminarViewModel(
				s.Id,
				s.Topic,
				s.Lecturer,
				s.Organizer.UserName,
				s.DateAndTime,
				s.Category.Name))
			.ToArrayAsync();

		return View(model);
	}

	public async Task<IActionResult> Leave(int id)
	{
		var seminarParticipant = await dbContext.SeminarsParticipants
			.Where(sp => sp.SeminarId == id
				&& sp.ParticipantId == GetUserId())
			.FirstOrDefaultAsync();

		//Check if joined seminar exist
		if (seminarParticipant == null)
		{
			return BadRequest();
		}

		dbContext.SeminarsParticipants.Remove(seminarParticipant);
		await dbContext.SaveChangesAsync();

		return RedirectToAction(nameof(Joined));
	}

	[HttpGet]
	public async Task<IActionResult> Details(int id)
	{
		var model = await dbContext
			.Seminars
			.Where(s => s.Id == id)
			.Select(s => new SeminarDetailsViewModel(
					s.Id,
					s.Topic,
					s.Lecturer,
					s.Details,
					s.Organizer.UserName,
					s.DateAndTime,
					s.Duration,
					s.Category.Name))
			.FirstOrDefaultAsync();

		//Check if the seminar exist
		if (model == null)
		{
			return BadRequest();
		}

		return View(model);
	}

	[HttpGet]
	public async Task<IActionResult> Delete(int id)
	{
		var seminar = await dbContext.Seminars.FindAsync(id);

		if (seminar == null)
		{
			return BadRequest();
		}

		string userId = GetUserId();

		if (seminar.OrganizerId != userId)
		{
			return Unauthorized();
		}

		var model = new SeminarDeleteViewModel(
					seminar.Id,
					seminar.Topic,
					seminar.DateAndTime);

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		var seminar = await dbContext.Seminars.FindAsync(id);

		if (seminar == null)
		{
			return BadRequest();
		}

		string userId = GetUserId();

		if (seminar.OrganizerId != userId)
		{
			return Unauthorized();
		}

		dbContext.Seminars.Remove(seminar);
		await dbContext.SaveChangesAsync();

		return RedirectToAction(nameof(All));
	}

	private string GetUserId()
		=> User.FindFirstValue(ClaimTypes.NameIdentifier);

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
