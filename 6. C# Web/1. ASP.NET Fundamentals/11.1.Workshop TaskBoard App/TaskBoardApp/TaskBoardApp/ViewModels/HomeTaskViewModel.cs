namespace TaskBoardApp.ViewModels;

public class HomeTaskViewModel
{
	public int AllTasksCount { get; set; }

	public IEnumerable<BoardsWithTasksViewModel> BoardsWithTasksCount = new HashSet<BoardsWithTasksViewModel>();
	public int UserTasksCount { get; set; }
}
