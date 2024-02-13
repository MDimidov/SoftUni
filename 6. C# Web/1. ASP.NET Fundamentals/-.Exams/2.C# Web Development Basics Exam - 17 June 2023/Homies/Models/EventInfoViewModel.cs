#nullable disable
using static Homies.Common.ValidationConstants.Event;

namespace Homies.Models;
public class EventInfoViewModel
{
	public EventInfoViewModel(
		int id,
		string name, 
		DateTime start,
		string type,
		string organaiser)
	{
		Id = id;
		Name = name;
		Type = type;
		Start = start.ToString(DateTimeFormat);
		Organiser = organaiser;
	}

	public int Id { get; set; }

	public string Name { get; set; }

	public string Start { get; set; }

	public string Type { get; set; }

	public string Organiser { get; set;}
}
