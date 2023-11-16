namespace Trucks.Common;

public static class ValidationConstants
{
    //Truck
    public const int TruckRegistrationNumberLength = 8;
    public const string TruckRegistrationNumberRegex = @"[A-Z]{2}\d{4}[A-Z]{2}";
    public const int TruckVinNumberLength = 17;
    public const int TruckTankCapacityMinRange = 950;
    public const int TruckTankCapacityMaxRange = 1420;
    public const int TruckCargoCapacityMinRange = 5000;
    public const int TruckCargoCapacityMaxRange = 29000;

    //Client
    public const int ClientNameMinLength = 3;
    public const int ClientNameMaxLength = 40;
    public const int ClientNationalityMinLength = 2;
    public const int ClientNationalityMaxLength = 40;

    //Despatcher
    public const int DespatcherNameMinLength = 2;
    public const int DespatcherNameMaxLength = 40;
}
