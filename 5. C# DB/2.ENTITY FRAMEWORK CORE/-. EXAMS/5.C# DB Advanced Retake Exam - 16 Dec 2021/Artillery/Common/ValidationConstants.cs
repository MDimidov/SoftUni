namespace Artillery.Common;

public static class ValidationConstants
{
    //Country
    public const int CountryNameMinLength = 4;
    public const int CountryNameMaxLength = 60;
    public const int CountryArmySizeMinRange = 50_000;
    public const int CountryArmySizeMaxRange = 10_000_000;

    //Manufacturer
    public const int ManufacturerNameMinLength = 4;
    public const int ManufacturerNameMaxLength = 40;
    public const int ManufacturerFoundedMinLength = 10;
    public const int ManufacturerFoundedMaxLength = 100;

    //Shell
    public const double ShellWeightMinRange = 2.0;
    public const double ShellWeightMaxRange = 1_680.0;
    public const int ShellCaliberMinLength = 4;
    public const int ShellCaliberMaxLength = 30;

    //Gun
    public const int GunWeightMinRange = 100;
    public const int GunWeightMaxRange = 1_350_000;
    public const double GunBarrelLengthMinRange = 2.0;
    public const double GunBarrelLengthMaxRange = 35.0;
    public const int GunRangeMinRange = 1;
    public const int GunRangeMaxRange = 100_000;
    public const int GunTypeMaxRange = 5;
}
