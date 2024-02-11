using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.ValidationConstants.Task;

namespace TaskBoardApp.Models.Task;


public class TaskFormModel
{
	public TaskFormModel()
	{
		Boards = new HashSet<TaskBoardModel>();
	}

	[Required]
	[StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
		ErrorMessage = TitleErrorMsg)]
	public string Title { get; set; } = null!;

	[Required]
	[StringLength(DesctipritonMaxLength, MinimumLength = DesctipritonMinLength,
		ErrorMessage = DescriptionErrorMsg)]
	public string Description { get; set; } = null!;

	[Display(Name = "Board")]
	public int? BoardId { get; set; }

	public IEnumerable<TaskBoardModel> Boards { get; set; }
}
