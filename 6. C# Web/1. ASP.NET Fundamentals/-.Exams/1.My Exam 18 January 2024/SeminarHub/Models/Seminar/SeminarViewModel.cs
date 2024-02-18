#nullable disable

using System.Globalization;
using static SeminarHub.Common.ValidationConstants.Seminar;

namespace SeminarHub.Models.Seminar;

public class SeminarViewModel
{
	public SeminarViewModel(
		int id,
		string topic,
		string lecturer,
		string organizer,
		DateTime dateAndTime,
		string category)
	{
		Id = id;
		Topic = topic;
		Lecturer = lecturer;
		Organizer = organizer;
		DateAndTime = dateAndTime.ToString(DateAndTimeFormat, CultureInfo.InvariantCulture);
		Category = category;
	}

	public int Id { get; set; }

	public string Topic { get; set; }

	public string Lecturer { get; set; }

	public string Organizer { get; set; }

	public string DateAndTime { get; set; }

	public string Category { get; set; }
}
