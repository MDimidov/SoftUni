using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.ViewModels;

namespace TaskBoardApp.Controllers;

public class TaskController : Controller
{
	private readonly TaskBoardAppDbContext dbContext;

	public TaskController(TaskBoardAppDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	[HttpGet]
	public async Task<IActionResult> Create()
	{
		var model = new TaskFormViewModel();
		model.Boards = await GetCategoryAsync();

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Create(TaskFormViewModel model)
	{
		var categories  = await GetCategoryAsync();
		if(!categories.Any(b => b.Id == model.BoardId))
		{
			ModelState.AddModelError(nameof(model.Id), "Category does not exist");
		}
		 
		if (!ModelState.IsValid)
		{
			model.Boards = await GetCategoryAsync();
			return View(model);
		}

		var task = new Data.Models.Task()
		{
			Title = model.Title,
			Description = model.Description,
			CreatedOn = DateTime.Now,
			BoardId = model.BoardId,
			OwnerId = GetUserId()
		};

		await dbContext.Tasks.AddAsync(task);
		await dbContext.SaveChangesAsync();	

		return RedirectToAction("All", "Board");
	}

	public async Task<IActionResult> Details(int id)
	{
		var taskModel = await dbContext.Tasks
			.Where(t => t.Id == id)
			.Select(t => new TaskDetailsViewModel(
				t.Id,
				t.Title,
				t.Description,
				t.Board.Name,
				t.Owner.UserName,
				t.CreatedOn))
			.FirstOrDefaultAsync();

		if(taskModel == null)
		{
			return BadRequest();
		}

		return View(taskModel);
	}

	public async Task<IActionResult> Edit(int id)
	{
		var task = await dbContext
			.Tasks
			.FindAsync(id);
			

		if(task == null)
		{
			return BadRequest();
		}

		string userId = GetUserId();

		if (task.OwnerId != userId)
		{
			return Unauthorized();
		}
		var taskModel = new TaskFormViewModel()
		{
			Id = task.Id,
			Title = task.Title,
			Description = task.Description,
			BoardId = task.BoardId,
			Boards = await GetCategoryAsync()
		};

		return View(taskModel);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(TaskFormViewModel taskModel)
	{
		if(!ModelState.IsValid)
		{
			taskModel.Boards = await GetCategoryAsync();

			return View(taskModel);
		}

		var task = await dbContext.Tasks.FindAsync(taskModel.Id);

		if(task != null)
		{
			task.Id = taskModel.Id;
			task.Title = taskModel.Title;
			task.Description = taskModel.Description;
			task.BoardId = taskModel.BoardId;

			await dbContext.SaveChangesAsync();

			return RedirectToAction("All", "Board");
		}

		return View(taskModel);
	}

	public async Task<IActionResult> Delete(int id)
	{
		var task = await dbContext.Tasks
			.Where(t => t.Id == id)
			.Include(t => t.Owner)
			.FirstOrDefaultAsync();

		if(task == null)
		{
			return BadRequest();
		}

		if(task.OwnerId != GetUserId())
		{
			return Unauthorized();
		}

		var taskModel = new TaskViewModel()
		{
			Title = task.Title,
			Description = task.Description,
			Id = task.Id,
			Owner = task.Owner.UserName
		};

		return View(taskModel);
	}

	private string GetUserId()
	{
		return User.FindFirstValue(ClaimTypes.NameIdentifier);
	}

	private async Task<IEnumerable<BoardViewModel>> GetCategoryAsync()
		=> await dbContext.Boards
		.AsNoTracking()
		.Select(b => new BoardViewModel
		{
			Id = b.Id,
			Name = b.Name,
		})
		.ToArrayAsync();
}
