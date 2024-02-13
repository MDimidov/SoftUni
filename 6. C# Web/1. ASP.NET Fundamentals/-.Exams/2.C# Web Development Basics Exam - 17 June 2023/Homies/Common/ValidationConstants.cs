namespace Homies.Common;

public static class ValidationConstants
{
	public static class Event
	{
		public const int NameMinLength = 5;
		public const int NameMaxLength = 20;
		public const string NameErrorMessage = "The field {0} must be between {2} and {1} charachters long";

		public const int DescriptionMinLength = 15;
		public const int DescriptionMaxLength = 150;
		public const string DescriptionErrorMessage = "The field {0} must be between {2} and {1} charachters long";

		public const string DateTimeRegex = @"\d{4}\-\d{2}\-\d{2}\s\d{1,2}:\d{2}";
		public const string DateTimeFormat = "yyyy-MM-dd HH:mm";

		public const string RequireErrorMessage = "The field {0} is required";

	}

	public static class Type
	{
		public const int NameMinLength = 5;
		public const int NameMaxLength = 15;
		//public const string NameErrorMessage = "The field {0} must be between {2} and {1} charachters long";
	}
}
