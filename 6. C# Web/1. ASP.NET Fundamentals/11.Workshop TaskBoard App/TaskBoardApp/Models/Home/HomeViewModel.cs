namespace TaskBoardApp.Models.Home;

public class HomeViewModel
{
	public HomeViewModel()
	{
		BoardsWithTasksCount = new HashSet<HomeBoardModel>();
	}
	public int AllTasksCount { get; set; }

	public IEnumerable<HomeBoardModel> BoardsWithTasksCount { get; set; }

	public int UserTasksCount { get; set; }
}
