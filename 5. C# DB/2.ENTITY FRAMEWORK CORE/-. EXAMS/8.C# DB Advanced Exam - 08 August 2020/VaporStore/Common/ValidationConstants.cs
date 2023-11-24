namespace VaporStore.Common;

public static class ValidationConstants
{
    //Game
    public const double GamePriceMinRange = 0.0;

    //User
    public const int UserUsernameMinLength = 3;
    public const int UserUsernameMaxLength = 20;
    public const string UserFullNameRegex = @"[A-Z][a-z]+\s[A-Z][a-z]+";
    public const int UserAgeMinRange = 3;
    public const int UserAgeMaxRange = 103;
    
    //Card
    public const string CardNumberRegex = @"\d{4}\s\d{4}\s\d{4}\s\d{4}";
    public const string CardCvcRegex = @"\d{3}";

    //Purchase
    public const string PurchaseProductKeyRegex = @"[A-Z\d]{4}\-[A-Z\d]{4}\-[A-Z\d]{4}";
}
