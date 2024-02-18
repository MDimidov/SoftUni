#nullable disable

using static SeminarHub.Common.ValidationConstants.Seminar;

namespace SeminarHub.Models.Seminar;

public class SeminarDeleteViewModel
{
	public SeminarDeleteViewModel(
		int id,
		string topic,
		DateTime dateAndTime)
	{
		Id = id;
		Topic = topic;
		DateAndTime = dateAndTime;//.ToString(DateAndTimeFormat);
	}

	public int Id { get; set; }

	public string Topic { get; set; }

	public DateTime DateAndTime { get; set; }
}
