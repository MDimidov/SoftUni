#nullable disable

using Library.Models.Category;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Library.Common.ErrorMessages;
using static Library.Common.ValidationConstants.Book;

namespace Library.Models.Book;

public class BookFormViewModel
{
	[Required(ErrorMessage = RequiredField)]
	[StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
		ErrorMessage = RequiredLength)]
	public string Title { get; set; }

	[Required(ErrorMessage = RequiredField)]
	[StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength,
		ErrorMessage = RequiredLength)]
	public string Author { get; set; }

	[Required(ErrorMessage = RequiredField)]
	[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
		ErrorMessage = RequiredLength)]
	public string Description { get; set; }

	[Required(ErrorMessage = RequiredField)]
	public string Url { get; set; }

	[Required(ErrorMessage = RequiredField)]
	[Range(RatingMinRange, RatingMaxRange,
		ErrorMessage = RequiredRange)]
	public decimal Rating { get; set; }

	[Required(ErrorMessage = RequiredField)]
	[DisplayName("Category")]
	public int CategoryId { get; set; }

	public IEnumerable<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();

}
