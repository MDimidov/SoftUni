#nullable disable

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Common.ValidationConstants.Task;

namespace TaskBoardApp.Data.Models;

public class Task
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; }

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; }

    public DateTime CreatedOn { get; set; }

    [ForeignKey(nameof(Board))]
    public int BoardId { get; set; }

    public virtual Board Board { get; set; }

    [Required]
    [ForeignKey(nameof(Owner))]
    public string OwnerId { get; set; }

    public virtual IdentityUser Owner { get; set; }
}


//the Task class should have the following properties:
//• Id – a unique integer, Primary Key
//• Title – a string with min length 5 and max length 70 (required)
//• Description – a string with min length 10 and max length 1000 (required)
//• CreatedOn – date and time
//• BoardId – an integer
//• Board – a Board object
//• OwnerId – an integer(required)
//• Owner – an IdentityUser object