using static SeminarHub.Common.ValidationConstants.Seminar;

namespace SeminarHub.Common;

public static class ErrorMessages
{
	public const string RequiredField = "Field {0} is required!";

	public const string RequiredLength = "Field {0} must be between {2} and {1} characters long!";

	public const string RequiredRange = "Value of field {0} must be between {1} and {2}!";

	public const string WrongDateTimeFormat = $"Required DateTime format is {DateAndTimeFormat}";
}
