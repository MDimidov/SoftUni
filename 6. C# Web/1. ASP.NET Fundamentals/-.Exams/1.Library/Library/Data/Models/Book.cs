#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Common.ValidationConstants.Book;

namespace Library.Data.Models;
public class Book
{
	[Key]
	public int Id { get; set; }

	[Required]
	[MaxLength(TitleMaxLength)]
	public string Title { get; set; }

	[Required]
	[MaxLength(AuthorMaxLength)]
	public string Author { get; set; }

	[Required]
	[MaxLength(DescriptionMaxLength)]
	public string Description { get; set; }

	[Required]
	public string ImageUrl { get; set; }


	[Required]
	public decimal Rating { get; set; }

	[Required]
	[ForeignKey(nameof(Category))]
	public int CategoryId { get; set; }

	public virtual Category Category { get; set; }

	public virtual ICollection<IdentityUserBook> UsersBooks { get; set; } = new HashSet<IdentityUserBook>();
}


