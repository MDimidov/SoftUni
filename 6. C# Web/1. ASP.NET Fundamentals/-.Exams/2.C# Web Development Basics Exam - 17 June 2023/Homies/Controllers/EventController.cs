using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using static Homies.Common.ValidationConstants.Event;

namespace Homies.Controllers;

[Authorize]
public class EventController : Controller
{
    private readonly HomiesDbContext dbContext;

    public EventController(HomiesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IActionResult> All()
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

        if (eventModel == null)
        {
            return BadRequest();
        }

        string userId = GetUserId();

        if (!eventModel.EventsParticipants.Any(ep => ep.HelperId == userId))
        {
            EventParticipant eventParticipant = new()
            {
                EventId = eventModel.Id,
                HelperId = userId
            };

            eventModel.EventsParticipants.Add(eventParticipant);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }
        
        return RedirectToAction(nameof(All));
    }

    [HttpPost]
    public async Task<IActionResult> Leave(int id)
    {
        var e = await dbContext
            .Events
            .Where(e => e.Id == id)
            .Include(e => e.EventsParticipants)
            .FirstOrDefaultAsync();

        if (e == null)
        {
            return BadRequest();
        }

        string userId = GetUserId();

        var ep = e.EventsParticipants
            .FirstOrDefault(ep => ep.HelperId == userId);

        if (ep == null)
        {
            return NotFound();
        }

        e.EventsParticipants.Remove(ep);

        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }


    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new EventFormViewModel();
        model.Types = await GetTypesAsync();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EventFormViewModel model)
    {
        if (!DateTime.TryParseExact(
            model.Start,
            DateTimeFormat,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime start
            ))
        {
            ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be {DateTimeFormat}");
        }

        if (!DateTime.TryParseExact(
            model.End,
            DateTimeFormat,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime end
            ))
        {
            ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be {DateTimeFormat}");
        }

        if (!ModelState.IsValid)
        {
            model.Types = await GetTypesAsync();

            return View(model);
        }

        string userId = GetUserId();

        Event e = new()
        {
            Name = model.Name,
            Description = model.Description,
            CreatedOn = DateTime.Now,
            Start = start,
            End = end,
            OrganiserId = userId,
            TypeId = model.TypeId,
        };

        await dbContext.Events.AddAsync(e);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var e = await dbContext
            .Events
            .FindAsync(id);
        if (e == null)
        {
            return BadRequest();
        }

        if (e.OrganiserId != GetUserId())
        {
            return Unauthorized();
        }


        var model = new EventFormViewModel()
        {
            Name = e.Name,
            Description = e.Description,
            Start = e.Start.ToString(DateTimeFormat),
            End = e.End.ToString(DateTimeFormat),
            TypeId = e.TypeId,
        };

        model.Types = await GetTypesAsync();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EventFormViewModel model, int id)
    {
        var e = await dbContext
            .Events
            .FindAsync(id);

        if (e == null)
        {
            return BadRequest();
        }

        if (e.OrganiserId != GetUserId())
        {
            return Unauthorized();
        }

        if (!DateTime.TryParseExact(
            model.Start,
            DateTimeFormat,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime start
            ))
        {
            ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be {DateTimeFormat}");
        }

        if (!DateTime.TryParseExact(
            model.End,
            DateTimeFormat,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime end
            ))
        {
            ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be {DateTimeFormat}");
        }

        if (!ModelState.IsValid)
        {
            model.Types = await GetTypesAsync();

            return View(model);
        }

        e.Start = start;
        e.End = end;
        e.Name = model.Name;
        e.Description = model.Description;
        e.TypeId = model.TypeId;

        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }

    public async Task<IActionResult> Details(int id)
    {
        var model = await dbContext
            .Events
            .AsNoTracking()
            .Where(e => e.Id == id)
            .Select(e => new EvenDetailsViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Start = e.Start.ToString(DateTimeFormat),
                End = e.End.ToString(DateTimeFormat),
                CreatedOn = e.CreatedOn.ToString(DateTimeFormat),
                Organiser = e.Organiser.UserName,
                Type = e.Type.Name
            })
            .FirstOrDefaultAsync();

        if (model == null)
        {
            return RedirectToAction(nameof(All));
        }

        return View(model);
    }

    private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

    private async Task<IEnumerable<TypeViewModel>> GetTypesAsync()
        => await dbContext
                    .Types
                    .AsNoTracking()
                    .Select(t => new TypeViewModel()
                    {
                        Id = t.Id,
                        Name = t.Name,
                    })
                    .ToArrayAsync();
}
