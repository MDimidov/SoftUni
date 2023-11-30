namespace SoftJail.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using CarDealer.Utilities;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
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
            StringBuilder sb = new();

            ImportPrisonerDto[] prisonerDtos = JsonConvert
                .DeserializeObject<ImportPrisonerDto[]>(jsonString)!;

            ICollection<Prisoner> validPrisoners = new HashSet<Prisoner>();

            foreach (var prisonerDto in prisonerDtos)
            {
                if(!IsValid(prisonerDto)
                    || !DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcerationDate))
                {
                    sb.AppendLine(ErrorMessage); 
                    continue;
                }

                DateTime? releaseDate = null;
                if (!String.IsNullOrWhiteSpace(prisonerDto.ReleaseDate))
                {
                    bool isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDateDt);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    releaseDate = releaseDateDt;
                }

                Prisoner prisoner = new()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate, 
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                };

                bool isAddressValid = true;

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto.Address))
                    {
                        isAddressValid = false;
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    prisoner.Mails.Add(new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    });
                }

                if(isAddressValid)
                {
                    validPrisoners.Add(prisoner);
                    sb.AppendLine(string.Format(SuccessfullyImportedPrisoner, prisoner.FullName, prisoner.Age));
                }
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new();

            ImportOfficerDto[] officerDtos = new XmlHelper()
                .Deserialize<ImportOfficerDto[]>(xmlString, "Officers");

            ICollection<Officer> validOfficers = new HashSet<Officer>();

            foreach(var officerDto in officerDtos)
            {
                if(!IsValid(officerDto)
                    || !Enum.TryParse<Position>(officerDto.Position, out var position)
                    || !Enum.TryParse<Weapon>(officerDto.Weapon, out var weapon))
                    
                {
                    sb.AppendLine(ErrorMessage); 
                    continue;
                }

                Officer officer = new()
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerDto.DepartmentId
                };

                foreach(var prisoner in  officerDto.Prisoners.DistinctBy(p => p.Id))
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        PrisonerId = prisoner.Id
                    });
                }

                validOfficers.Add(officer);
                sb.AppendLine(string.Format(SuccessfullyImportedOfficer, officer.FullName, officer.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
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