using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Controllers;

[Authorize]
public class TaskController : Controller
{
	private readonly TaskBoardAppDbContext data;

	public TaskController(TaskBoardAppDbContext data)
	{
		this.data = data;
	}

	[HttpGet]
	public async Task<IActionResult> Create()
	{
		TaskFormModel taskModel = new()
		{
			Boards = GetBoards()
		};

		return View(taskModel);
	}

	[HttpPost]
	public async Task<IActionResult> Create(TaskFormModel taskModel)
	{
		if(!GetBoards().Any(b => b.Id == taskModel.BoardId))
		{
			ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist");
		}

		string currentUserId = GetUserId();

		if(!ModelState.IsValid)
		{
			taskModel.Boards = GetBoards();

			return View(taskModel);
		}

		Task task = new()
		{
			Title = taskModel.Title,
			Decription = taskModel.Description,
			CreatedOn = DateTime.Now,
			BoardId = taskModel.BoardId,
			OwnerId = currentUserId
		};

		await data.Tasks.AddAsync(task);
		await data.SaveChangesAsync();

		var boards = data.Boards;

		return RedirectToAction("All", "Board");
	}

	public async Task<IActionResult> Details(int id)
	{
		var task = await data
			.Tasks
			.Select(t => new TaskDetailsViewModel()
			{
				Id = t.Id,
				Title = t.Title,
				Description = t.Decription,
				CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
				Board = t.Board!.Name,
				Owner = t.Owner.UserName
			})
			.FirstOrDefaultAsync();

		if(task == null)
		{
			return BadRequest();
		}

		return View(task);
	}

	public async Task<IActionResult> Edit(int id)
	{
		Task? task = await data.Tasks
			.FindAsync(id);

		if (task == null)
		{
			return BadRequest();
		}

		string currentUserId = GetUserId();

		if(currentUserId != task.OwnerId)
		{
			return Unauthorized();
		}

		TaskFormModel taskModel = new TaskFormModel()
		{
			Title = task.Title,
			Description = task.Decription,
			BoardId = task.BoardId,
			Boards = GetBoards()
		};
		

		return View(taskModel);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
	{
		var task = await data.Tasks.FindAsync(id);

		if(task == null)
		{
			return BadRequest();
		}

		string currentUserId = GetUserId();

		if(currentUserId != task.OwnerId)
		{
			return Unauthorized();
		}

		if(!GetBoards().Any(b => b.Id == taskModel.BoardId))
		{
			ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
		}

		if(!ModelState.IsValid)
		{
			taskModel.Boards = GetBoards();

			return View(taskModel);
		}

		task.Title = taskModel.Title;
		task.Decription = taskModel.Description;
		task.BoardId = taskModel.BoardId;

		await data.SaveChangesAsync();
		return RedirectToAction("All", "Board");
	}

	public async Task<IActionResult> Delete(int id)
	{
		var task = await data.Tasks.FindAsync(id);

		if(task == null)
		{
			return BadRequest();
		}

		string currentUserId = GetUserId();
		if(currentUserId != task.OwnerId)
		{
			return Unauthorized();
		}

		TaskViewModel taskModel = new()
		{
			Id = task.Id,
			Title = task.Title,
			Description = task.Decription,
		};

		return View(taskModel);
	}

	[HttpPost]
	public async Task<IActionResult> Delete(TaskViewModel taskModel)
	{
		var task = await data.Tasks.FindAsync(taskModel.Id);

		if(task == null)
		{
			return BadRequest();
		}

		string currentUserId = GetUserId();
		if(task.OwnerId != currentUserId)
		{
			return Unauthorized();
		}

		data.Tasks.Remove(task);
		await data.SaveChangesAsync();
		return RedirectToAction("All", "Board");
	}

	private string GetUserId()
		=> User.FindFirstValue(ClaimTypes.NameIdentifier);

	private IEnumerable<TaskBoardModel> GetBoards()
		=> data.Boards
		.Select(b => new TaskBoardModel
		{
			Id = b.Id,
			Name = b.Name,
		});
}
