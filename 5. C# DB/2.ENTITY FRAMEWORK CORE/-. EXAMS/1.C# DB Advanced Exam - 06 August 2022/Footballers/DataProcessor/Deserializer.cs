namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Runtime.ConstrainedExecution;
    using System.Text;
    using System.Xml.Serialization;
    using static System.Net.Mime.MediaTypeNames;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new();

            XmlRootAttribute root = new("Coaches");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCoachDto[]), root);

            StringReader reader = new(xmlString);

            ImportCoachDto[] coachDtos = (ImportCoachDto[])serializer.Deserialize(reader)!;

            HashSet<Coach> validCoaches = new();

            foreach (ImportCoachDto coachDto in coachDtos)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(coachDto.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                Coach coach = new()
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality,
                };

                foreach (ImportFootballerDto footballer in coachDto.Footballers)
                {
                    if (!IsValid(footballer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    string pattern = "dd/MM/yyyy";
                    DateTime csd;
                    if (!DateTime.TryParseExact(footballer.ContractStartDate, pattern, CultureInfo.InvariantCulture,
                                               DateTimeStyles.None,
                                               out csd))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime ced;
                    if (!DateTime.TryParseExact(footballer.ContractEndDate, pattern, CultureInfo.InvariantCulture,
                                               DateTimeStyles.None,
                                               out ced))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;

                    }

                    if(csd > ced)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    coach.Footballers
                        .Add(new Footballer
                    {
                        Name = footballer.Name,
                        ContractStartDate = csd,
                        ContractEndDate = ced,
                        BestSkillType = (BestSkillType)footballer.BestSkillType,
                        PositionType = (PositionType)footballer.PositionType
                    });
                }

                validCoaches.Add(coach);

                sb.AppendLine(String.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
