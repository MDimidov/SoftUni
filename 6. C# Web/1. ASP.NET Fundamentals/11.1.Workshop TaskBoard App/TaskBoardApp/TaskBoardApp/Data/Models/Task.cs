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


