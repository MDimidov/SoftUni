#nullable disable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.ErrorMessages;
using static TaskBoardApp.Common.ValidationConstants.Task;

namespace TaskBoardApp.ViewModels;

public class TaskFormViewModel
{
	public int Id { get; set; }

	[Required(ErrorMessage = RequiredField)]
	[StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
		ErrorMessage = RequiredLength)]
	public string Title { get; set; }

	[Required(ErrorMessage = RequiredField)]
	[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
		ErrorMessage = RequiredLength)]
	public string Description { get; set; }

	[DisplayName("Category")]
	public int BoardId { get; set; }

	public IEnumerable<BoardViewModel> Boards { get; set; } = new HashSet<BoardViewModel>();
}
