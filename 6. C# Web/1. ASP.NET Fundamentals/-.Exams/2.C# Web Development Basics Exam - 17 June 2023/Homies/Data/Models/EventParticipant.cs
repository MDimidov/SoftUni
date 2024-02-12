using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models;

public class EventParticipant
{
	[ForeignKey(nameof(Helper))]
	public string HelperId { get; set; } = null!;

	public IdentityUser Helper { get; set; } = null!;


	[ForeignKey(nameof(Event))]
	public int EventId { get; set; }

	public virtual Event Event { get; set; } = null!;
}


//•	HelperId – a string, Primary Key, foreign key(required)
//•	Helper – IdentityUser
//•	EventId – an integer, Primary Key, foreign key(required)
//•	Event – Event
