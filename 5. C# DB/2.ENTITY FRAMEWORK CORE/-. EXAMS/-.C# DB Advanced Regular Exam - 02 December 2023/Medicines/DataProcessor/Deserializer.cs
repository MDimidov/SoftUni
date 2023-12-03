namespace Medicines.DataProcessor
{
    using CarDealer.Utilities;
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            StringBuilder sb = new();

            ImportPharmacyDto[] pharmacyDtos = new XmlHelper()
                .Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            ICollection<Pharmacy> validPharmacies = new HashSet<Pharmacy>();

            foreach(var pharmacyDto  in pharmacyDtos)
            {
                if (!IsValid(pharmacyDto)
                    || !bool.TryParse(pharmacyDto.IsNonStop, out bool isNonStop))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy pharmacy = new()
                {
                    Name = pharmacyDto.Name,
                    PhoneNumber = pharmacyDto.PhoneNumber,
                    IsNonStop = isNonStop
                };

                foreach(var medicineDto in pharmacyDto.Medicines)
                {

                    if (!IsValid(medicineDto)
                        || pharmacy.Medicines
                                .Any(m => m.Name == medicineDto.Name && m.Producer == medicineDto.Producer)
                        || !DateTime.TryParseExact(medicineDto.ProductionDate, "yyyy-MM-dd", 
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime productionDate)
                        || !DateTime.TryParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd",
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expiryDate)
                        || productionDate >= expiryDate)
                    {
                        sb.AppendLine(ErrorMessage); 
                        continue;
                    }

                    pharmacy.Medicines.Add(new Medicine
                    {
                        Name = medicineDto.Name,
                        Category = (Category)medicineDto.Category,
                        Price = medicineDto.Price,
                        ProductionDate = productionDate,
                        ExpiryDate = expiryDate,
                        Producer = medicineDto.Producer,
                    });

                }

                validPharmacies.Add(pharmacy);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(validPharmacies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder sb = new();

            ImportPatientDto[] patientDtos = JsonConvert
                .DeserializeObject<ImportPatientDto[]>(jsonString)!;

            ICollection<Patient> validPatients = new HashSet<Patient>();

            // Medicine[] = context.Medicines

            foreach (var patientDto in patientDtos)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = new()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender,
                };

                foreach (int medicineId in patientDto.Medicines)
                {
                    if (patient.PatientsMedicines.Any(pm => pm.MedicineId == medicineId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    patient.PatientsMedicines.Add(new PatientMedicine
                    {
                        MedicineId = medicineId
                    });
                }

                validPatients.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(validPatients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
