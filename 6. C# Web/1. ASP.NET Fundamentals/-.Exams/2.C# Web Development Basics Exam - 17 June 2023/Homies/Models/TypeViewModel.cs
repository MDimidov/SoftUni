//using System.ComponentModel.DataAnnotations;
//using static Homies.Common.ValidationConstants.Type;

namespace Homies.Models;

public class TypeViewModel
{
	public int Id { get; set; }

	//[Required]
	//[StringLength(NameMaxLength, MinimumLength = NameMinLength,
	//	ErrorMessage = NameErrorMessage)]
	public string Name { get; set; } = null!;
}
