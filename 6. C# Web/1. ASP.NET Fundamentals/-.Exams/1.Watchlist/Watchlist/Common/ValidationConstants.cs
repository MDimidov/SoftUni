namespace Watchlist.Common;

public static class ValidationConstants
{
    public static class User
    {
        public const int UserNameMinLength = 5;
        public const int UserNameMaxLength = 20;

        public const int EmailMinLength = 10;
        public const int EmailMaxLength = 60;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;
    }

    public static class Movie
    {
        public const int TitleMinLength = 10;
        public const int TitleMaxLength = 50;

        public const int DirectorMinLength = 5;
        public const int DirectorMaxLength = 50;

        public const double RatingMinRange = 0.0;
        public const double RatingMaxRange = 10.0;
    }

    public static class Genre
    {
        public const int NameMinLength = 5; 
        public const int NameMaxLength = 50; 
    }
}
