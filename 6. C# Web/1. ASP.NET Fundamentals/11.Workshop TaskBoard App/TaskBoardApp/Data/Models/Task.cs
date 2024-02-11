using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Common.ValidationConstants.Task;

namespace TaskBoardApp.Data.Models;

[Comment("Task table")]
public class Task
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(DesctipritonMaxLength)]
    public string Decription { get; set; } = null!;

    [Required]
    public DateTime CreatedOn { get; set; }

    [ForeignKey(nameof(Board))]
    public int? BoardId { get; set; }
    public virtual Board? Board { get; set; }

    [Required]
    [ForeignKey(nameof(Owner))]
    [Comment("Identity User")]
    public string OwnerId { get; set; } = null!;
    public virtual IdentityUser Owner { get; set; } = null!;

}
