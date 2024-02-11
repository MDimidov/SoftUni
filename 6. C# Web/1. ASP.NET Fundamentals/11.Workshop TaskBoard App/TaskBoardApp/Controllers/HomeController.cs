using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;
using TaskBoardApp.Models.Home;

namespace TaskBoardApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly TaskBoardAppDbContext data;

		public HomeController(TaskBoardAppDbContext data)
		{
			this.data = data;
		}

		public async Task<IActionResult> Index()
		{
			var taskBoars = data
				.Boards
				.Select(b => b.Name)
				.Distinct();

			var tasksCounts = new List<HomeBoardModel> ();
			foreach (var boardName in  taskBoars)
			{
				var tasksInBoard = data.Tasks
					.Where(t => t.Board.Name == boardName)
					.Count();

				tasksCounts.Add(new HomeBoardModel()
				{
					BoardName = boardName,
					TasksCount = tasksInBoard
				});
			}

			var userTasksCount = -1;

			if (User.Identity.IsAuthenticated)
			{
				var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				userTasksCount = data.Tasks
					.Where(t => t.OwnerId == currentUserId)
					.Count();
			}

			var homeModel = new HomeViewModel()
			{
				AllTasksCount = data.Tasks.Count(),
				BoardsWithTasksCount = tasksCounts,
				UserTasksCount = userTasksCount
			};

			return View(homeModel);	
		}


	}
}
