namespace Medicines.Common;

public class ValidationConstants
{
    //Pharmacy
    public const int PharmacyNameMinLength = 2;
    public const int PharmacyNameMaxLength = 50;
    public const int PharmacyPhoneNumberLength = 14;
    public const string PharmacyPhoneRegex = @"\([\d]{3}\)\s\d{3}\-\d{4}";

    //Medicine
    public const int MedicineNameMinLength = 3;
    public const int MedicineNameMaxLength = 150;
    public const double MedicinePriceMinRange = 0.01;
    public const double MedicinePriceMaxRange = 1000.0;
    public const int MedicineProducerMinLength = 3;
    public const int MedicineProducerMaxLength = 100;

    //Patient
    public const int PatientFullNameMinLength = 5;
    public const int PatientFullNameMaxLength = 100;

}
