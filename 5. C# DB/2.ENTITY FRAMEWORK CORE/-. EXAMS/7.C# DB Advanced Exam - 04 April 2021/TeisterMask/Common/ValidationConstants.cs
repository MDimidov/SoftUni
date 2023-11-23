namespace TeisterMask.Common;

public static class ValidationConstants
{
    //Employee
    public const int EmployeeUsernameMinLength = 3;
    public const int EmployeeUsernameMaxLength = 40;
    public const string EmployeeUsernameRegex = @"[a-zA-z\d]{3,}";
    public const string EmployeePhoneRegex = @"\d{3}\-\d{3}\-\d{4}";

    //Project
    public const int ProjectNameMinLength = 2;
    public const int ProjectNameMaxLength = 40;

    //Task
    public const int TaskNameMinLength = 2;
    public const int TaskNameMaxLength = 40;
    public const int TaskExecutionTypeMaxRnge = 3;
    public const int TaskLabelTypeMaxRnge = 4;

}
