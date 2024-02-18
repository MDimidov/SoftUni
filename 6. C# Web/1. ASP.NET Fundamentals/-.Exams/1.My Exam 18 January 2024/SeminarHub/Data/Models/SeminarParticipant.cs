#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Models;

[Comment("Mapping table between Seminar and IdentityUser")]
public class SeminarParticipant
{
	[Required]
	[ForeignKey(nameof(Seminar))]
	[Comment("Seminar ID")]
	public int SeminarId { get; set; }
	public virtual Seminar Seminar { get; set; }


	[Required]
	[ForeignKey(nameof(Participant))]
	[Comment("Identity User ID")]
	public string ParticipantId { get; set;}
	public virtual IdentityUser Participant { get; set; }
}
