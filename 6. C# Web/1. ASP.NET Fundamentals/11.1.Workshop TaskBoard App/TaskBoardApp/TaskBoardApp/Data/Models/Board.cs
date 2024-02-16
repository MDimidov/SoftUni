#nullable disable

using Humanizer;
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.ValidationConstants.Board;

namespace TaskBoardApp.Data.Models;

public class Board
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
}

//The Board class should have the following properties:
//• Id – a unique integer, Primary Key
//• Name – a string with min length 3 and max length 30 (required)
//• Tasks – a collection of Task

