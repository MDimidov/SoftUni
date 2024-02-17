using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Library.Common;

public static class ValidationConstants
{
	public static class Book
	{
		public const int TitleMinLength = 10;
		public const int TitleMaxLength = 50;

		public const int AuthorMinLength = 5;
		public const int AuthorMaxLength = 50;

		public const int DescriptionMinLength = 5;
		public const int DescriptionMaxLength = 5000;

		public const double RatingMinRange = 0.0;
		public const double RatingMaxRange = 10.0;

		//• Has Id – a unique integer, Primary Key
		//• Has Title – a string with min length 10 and max length 50 (required)
		//• Has Author – a string with min length 5 and max length 50 (required)
		//• Has Description – a string with min length 5 and max length 5000 (required)
		//• Has ImageUrl – a string (required)
		//• Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
		//• Has CategoryId – an integer, foreign key(required)
		//• Has Category – a Category(required)
		//• Has UsersBooks – a collection of type IdentityUserBook
	}

	public static class Category
	{
		public const int NameMinLength = 5;
		public const int NameMaxLength = 50;

		//• Has Id – a unique integer, Primary Key
		//• Has Name – a string with min length 5 and max length 50 (required)
		//• Has Books – a collection of type Books
	}


}
