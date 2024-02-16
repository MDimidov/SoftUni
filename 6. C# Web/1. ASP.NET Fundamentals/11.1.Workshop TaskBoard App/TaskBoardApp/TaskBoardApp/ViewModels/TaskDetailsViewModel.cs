#nullable disable

using static TaskBoardApp.Common.ValidationConstants.Task;

namespace TaskBoardApp.ViewModels;

public class TaskDetailsViewModel
{
	public TaskDetailsViewModel(
		int id,
		string title,
		string description,
		string board,
		string owner,
		DateTime createdOn)
	{
		Id = id; 
		Title = title; 
		Description = description;
		Board = board;
		Owner = owner;
		CreatedOn = createdOn.ToString(DateFormat);
	}

	public int Id { get; set; }

	public string Title { get; set; }

	public string Description { get; set; }

	public string Board {  get; set; }

	public string Owner { get; set; }

	public string CreatedOn { get; set; }

}
