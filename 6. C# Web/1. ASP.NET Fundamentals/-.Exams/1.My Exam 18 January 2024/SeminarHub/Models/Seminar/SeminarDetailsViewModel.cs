using System.Globalization;
using static SeminarHub.Common.ValidationConstants.Seminar;

namespace SeminarHub.Models.Seminar;

public class SeminarDetailsViewModel
{
	public SeminarDetailsViewModel(
		int id,
		string topic,
		string lecturer,
		string details,
		string organizer,
		DateTime dateAndTime,
		int? duration,
		string category)
	{
		Id = id;
		Topic = topic;
		Lecturer = lecturer;
		Details = details;
		Organizer = organizer;
		DateAndTime = dateAndTime.ToString(DateAndTimeFormat, CultureInfo.InvariantCulture);
		Duration = duration;
		Category = category;
	}

	public int Id { get; set; }

	public string Topic { get; set; }

	public string Lecturer { get; set; }

	public string Details { get; set; }

	public string Organizer { get; set; }

	public string DateAndTime { get; set; }

	public int? Duration { get; set; }

	public string Category { get; set; }
}
