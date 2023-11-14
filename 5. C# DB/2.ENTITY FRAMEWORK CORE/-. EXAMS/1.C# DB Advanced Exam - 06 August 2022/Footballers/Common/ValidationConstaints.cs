namespace Footballers.Common;

public static class ValidationConstaints
{
    //Footballer
    public const int FootballerNameMinLength = 2;
    public const int FootballerNameMaxLength = 40;

    //Team
    public const int TeamNameMinLength = 3;
    public const int TeamNameMaxLength = 40;
    public const string TeamNameRegex = @"^[a-zA-Z\d\.\-\ ]{3,}$";
    public const int TeamNationalityMinLength = 2;
    public const int TeamNationalityMaxLength = 40;

    //Coach
    public const int CooachNameMinLength = 2;
    public const int CooachNameMaxLength = 40;
}
