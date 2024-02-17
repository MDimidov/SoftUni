using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.ViewModels;

namespace TaskBoardApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly TaskBoardAppDbContext dbContext;

		public HomeController(TaskBoardAppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IActionResult> Index()
		{
			var taskBoards = await dbContext
				.Tasks
				.AsNoTracking()
				.ToArrayAsync();

			if (taskBoards == null)
			{
				return NotFound();
			}


			var model = new HomeTaskViewModel
			{
				AllTasksCount = taskBoards.Length,
				UserTasksCount = taskBoards
								.Count(t => t.OwnerId == GetUserId())
			};

			model.BoardsWithTasksCount = await dbContext
				.Boards
				.Select(b => new BoardsWithTasksViewModel
				{
					BoardName = b.Name,
					TasksCount = b.Tasks.Count()
				})
				.ToArrayAsync();


			return View(model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		private string GetUserId()
			=> User.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
