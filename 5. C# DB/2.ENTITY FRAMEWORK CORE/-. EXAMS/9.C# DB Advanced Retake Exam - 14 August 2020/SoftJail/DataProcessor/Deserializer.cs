namespace SoftJail.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new();

            ImportDepartmentDto[] departmentDtos = JsonConvert
                .DeserializeObject<ImportDepartmentDto[]>(jsonString)!;

            ICollection<Department> validDepartments = new HashSet<Department>();

            foreach (var departmentDto in departmentDtos)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department department = new()
                {
                    Name = departmentDto.Name
                };

                bool isCellNumberValid = true;

                foreach (var cellDto in departmentDto.Cells)
                {
                    if (cellDto.CellNumber < 1 || cellDto.CellNumber > 1000)
                    {
                        isCellNumberValid = false;
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    if (!IsValid(cellDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Cell cell = new()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };

                    department.Cells.Add(cell);
                }
                if (isCellNumberValid)
                {
                    validDepartments.Add(department);
                    sb.AppendLine(string.Format(SuccessfullyImportedDepartment, department.Name, department.Cells.Count));
                }
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}