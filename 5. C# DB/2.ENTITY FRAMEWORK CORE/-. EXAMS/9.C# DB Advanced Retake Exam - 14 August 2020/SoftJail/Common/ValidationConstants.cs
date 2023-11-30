namespace SoftJail.Common;

public static class ValidationConstants
{
    //Prisoner
    public const int PrisonerFullNameMinLength = 3;
    public const int PrisonerFullNameMaxLength = 20;
    public const string PrisonerNicknameRegex = @"The [A-Z][a-z]+";
    public const int PrisonerAgeMinRange= 18;
    public const int PrisonerAgeMaxRange= 65;
    public const double PrisoberBailMinRange = 0;
    public const double PrisoberBailMaxRange = (double)decimal.MaxValue; //this may be wrong in judge

    //Officer
    public const int OfficerFullNameMinLength = 3;
    public const int OfficerFullNameMaxLength = 30;
    public const double OfficerSalaryMinRange = 0;
    public const double OfficerSalaryMaxRange = (double)decimal.MaxValue; //this may be wrong in judge
    //public const int OfficerPositionMaxRanga = 3;

    //Cell
    public const int CellNumberMinRange = 1;
    public const int CellNumberMaxRange = 1000;

    //Mail
    public const string MailAddressRegex = @"[\w\s\d]+str\.";

    //Department
    public const int DepartmentNameMinLength = 3;
    public const int DepartmentNameMaxLength = 25;
}
