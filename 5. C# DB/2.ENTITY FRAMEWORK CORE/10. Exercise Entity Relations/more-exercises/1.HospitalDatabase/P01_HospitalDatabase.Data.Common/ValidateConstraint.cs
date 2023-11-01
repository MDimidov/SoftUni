namespace P01_HospitalDatabase.Data.Common;

public static class ValidateConstraint
{
    // Patient
    public const int PatientNameMaxLength = 50;
    public const int PatientAddressMaxLength = 250;
    public const int PatientEmailMaxLength = 80;

    // Visitation
    public const int VisitationCommentsMaxLength = 250;

    // Diagnose
    public const int DiagnoseNameMaxLength = 50;
    public const int DiagnosenCommentsMaxLength = 250;

    // Medicament
    public const int MedicamentNameMaxLength = 50;

    // Doctor
    public const int DoctorNameMaxLength = 100;
    public const int SpecialityNameMaxLength = 100;


}
