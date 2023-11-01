﻿namespace P02_FootballBetting.Data.Common;

public static class ValidationConstants
{
    // Team
    public const int TeamNameMaxLength = 50;
    public const int TeamLogoUrlMaxLength = 2048;
    public const int TeamInitialsMaxLength = 4;

    // Color
    public const int ColorNameMaxLength = 20;

    // Town
    public const int TownNameMaxLength = 100;

    // Country
    public const int CountryNameMaxLength = 56;

    // Player
    public const int PlayerNameMaxLength = 100;

    // Position
    public const int PositionNameMaxLength = 50;

    // User
    public const int UserUsernameMaxLength = 36;
    public const int UserPasswordMaxLength = 256;
    public const int UserEmailMaxLength = 256;
    public const int UserNameMaxLength = 100;
}
