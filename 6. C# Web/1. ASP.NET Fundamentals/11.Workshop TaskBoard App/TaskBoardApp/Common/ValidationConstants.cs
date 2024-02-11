namespace TaskBoardApp.Common;

public static class ValidationConstants
{
	public static class Task
	{
		public const int TitleMinLength = 5;
		public const int TitleMaxLength = 70;
		public const string TitleErrorMsg = "Title should be at least {2} character long.";

		public const int DesctipritonMinLength = 10;
		public const int DesctipritonMaxLength = 1000;
		public const string DescriptionErrorMsg = "Description should be at least {2} character long.";
	}

	public static class Board
	{
		public const int NameMinLength = 3;
		public const int NameMaxLength = 30;
	}
}
