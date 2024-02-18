#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SeminarHub.Common.ValidationConstants.Seminar;

namespace SeminarHub.Data.Models;

[Comment("Seminar table")]
public class Seminar
{
	[Key]
	[Comment("Primary key")]
	public int Id { get; set; }

	[Required]
	[MaxLength(TopicMaxLength)]
	[Comment("Seminar topic")]
	public string Topic { get; set; }

	[Required]
	[MaxLength(LecturerMaxLength)]
	[Comment("Seminar lecturer")]
	public string Lecturer { get; set; }

	[Required]
	[MaxLength(DetailsMaxLength)]
	[Comment("Seminar details")]
	public string Details { get; set; }

	[Required]
	[ForeignKey(nameof(Organizer))]
	[Comment("IdentityUser ID - Foreign key")]
	public string OrganizerId { get; set; }
	public virtual IdentityUser Organizer { get; set; }

	[Required]
	[Comment("Seminar Date and Time")]
	public DateTime DateAndTime { get; set; }

	[Comment("Seminar duration")]
	public int? Duration { get; set; }

	[Required]
	[ForeignKey(nameof(Category))]
	[Comment("Category ID - Foreign key")]
	public int CategoryId { get; set; }

	public virtual Category Category { get; set; }

	public virtual ICollection<SeminarParticipant> SeminarsParticipants { get; set;} = new HashSet<SeminarParticipant>();
}


//•	Has Id – a unique integer, Primary Key
//•	Has Topic – string with min length 3 and max length 100 (required)
//•	Has Lecturer – string with min length 5 and max length 60 (required)
//•	Has Details – string with min length 10 and max length 500 (required)
//•	Has OrganizerId – string (required)
//•	Has Organizer – IdentityUser (required)
//•	Has DateAndTime – DateTime with format "dd/MM/yyyy HH:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//•	Has Duration – integer value between 30 and 180
//•	Has CategoryId – integer, foreign key (required)
//•	Has Category – Category (required)
//•	Has SeminarsParticipants – a collection of type SeminarParticipant
