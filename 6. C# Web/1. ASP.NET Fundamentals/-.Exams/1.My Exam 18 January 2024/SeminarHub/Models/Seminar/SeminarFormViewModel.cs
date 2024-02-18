#nullable disable

using SeminarHub.Models.Category;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Common.ValidationConstants.Seminar;
using static SeminarHub.Common.ErrorMessages;

namespace SeminarHub.Models.Seminar;

public class SeminarFormViewModel
{
	[Required(ErrorMessage = RequiredField)]
	[StringLength(TopicMaxLength, MinimumLength = TopicMinLength,
		ErrorMessage = RequiredLength)]
	public string Topic { get; set; }

	[Required(ErrorMessage = RequiredField)]
	[StringLength(LecturerMaxLength, MinimumLength = LecturerMinLength,
		ErrorMessage = RequiredLength)]
	public string Lecturer { get; set; }

	[Required(ErrorMessage = RequiredField)]
	[StringLength(DetailsMaxLength, MinimumLength = DetailsMinLength,
		ErrorMessage = RequiredLength)]
	public string Details { get; set; }

	[Required(ErrorMessage = RequiredField)]
	public string DateAndTime { get; set; }

	[Range(DurationMinRange, DurationMaxRange, ErrorMessage = RequiredRange)]
	public int? Duration { get; set; }

	[Required]
	public int CategoryId { get; set; }

	public IEnumerable<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();
}
