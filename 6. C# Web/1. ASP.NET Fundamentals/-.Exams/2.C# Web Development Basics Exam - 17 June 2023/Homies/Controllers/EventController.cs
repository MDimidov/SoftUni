using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace Homies.Controllers;

[Authorize]
public class EventController : Controller
{
	private readonly HomiesDbContext dbContext;

	public EventController(HomiesDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	public async Task <IActionResult> All()
	{
		var events = await dbContext
			.Events
			.AsNoTracking()
			.Select(e => new EventInfoViewModel(
				e.Id, 
				e.Name, 
				e.Start, 
				e.Type.Name, 
				e.Organiser.UserName))
			.ToArrayAsync();

		return View(events);
	}


	[HttpGet]
	public async Task<IActionResult> Joined()
	{
		string userId = GetUserId();

		var model = await dbContext
			.EventsParticipants
			.AsNoTracking()
			.Where(ep => ep.HelperId == userId)
			.Select(ep => new EventInfoViewModel(
				ep.EventId,
				ep.Event.Name,
				ep.Event.Start,
				ep.Event.Type.Name,
				ep.Event.Organiser.UserName))
			.ToArrayAsync();

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Join(int id)
	{
		var eventModel = await dbContext
			.Events
			.Where(e => e.Id == id)
			.Include(e => e.EventsParticipants)
			.FirstOrDefaultAsync();

		if(eventModel == null)
		{
			return BadRequest();
		}

		string userId = GetUserId();	

		if(!eventModel.EventsParticipants.Any(ep => ep.HelperId == userId))
		{
			EventParticipant eventParticipant = new()
			{
				EventId = eventModel.Id,
				HelperId = userId
			};

			eventModel.EventsParticipants.Add(eventParticipant);
			await dbContext.SaveChangesAsync();
		}

		return RedirectToAction(nameof(Joined));
	}


	private string GetUserId()
		=> User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
}
