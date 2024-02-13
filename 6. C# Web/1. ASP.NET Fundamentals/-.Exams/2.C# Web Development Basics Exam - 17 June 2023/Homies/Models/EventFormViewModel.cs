using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Homies.Common.ValidationConstants.Event;

namespace Homies.Models
{
	public class EventFormViewModel
	{
		public EventFormViewModel()
		{
			Types = new HashSet<TypeViewModel>();
		}

		[Required(ErrorMessage = RequireErrorMessage)]		
		[StringLength(NameMaxLength, MinimumLength = NameMinLength,
			ErrorMessage = NameErrorMessage)]
		public string Name { get; set; } = null!;

		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
			ErrorMessage = DescriptionErrorMessage)]
		public string Description { get; set; } = null!;

		[Required(ErrorMessage = RequireErrorMessage)]
		public string Start { get; set; }

		[Required(ErrorMessage = RequireErrorMessage)]
		public string End { get; set; }

		public int TypeId { get; set; }

		public IEnumerable<TypeViewModel> Types { get; set; }
	}
}
