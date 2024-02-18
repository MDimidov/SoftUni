#nullable disable

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Common.ValidationConstants.Category;

namespace SeminarHub.Data.Models;

[Comment("Category table")]
public class Category
{
	[Key]
	[Comment("Primary key")]
	public int Id { get; set; }

	[Required]
	[MaxLength(NameMaxLength)]
	[Comment("Category name")]
	public string Name { get; set; }

	public virtual ICollection<Seminar> Seminars { get; set; } = new HashSet<Seminar>();
}

//•	Has Id – a unique integer, Primary Key
//•	Has Name – string with min length 3 and max length 50 (required)
//•	Has Seminars – a collection of type Seminar

