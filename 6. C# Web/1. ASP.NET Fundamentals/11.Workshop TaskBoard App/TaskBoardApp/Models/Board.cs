using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.ValidationConstants.Board;

namespace TaskBoardApp.Models;

public class Board
{
	public Board()
	{
		Tasks = new HashSet<Task>();
	}

	[Key]
	public int Id { get; set; }

	[Required]
	[MaxLength(NameMaxLength)]
	public string Name { get; set; } = null!;

	public virtual ICollection<Task> Tasks { get; set; }
}
