namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            StringBuilder sb = new();

            ExportCoachDto[] coaches = context.Coaches
                .AsNoTracking()
                .Where(x => x.Footballers.Any())
                .OrderByDescending(c => c.Footballers.Count)
                .ThenBy(c => c.Name)
                .Select(c => new ExportCoachDto
                {
                    FootballersCount = c.Footballers.Count,
                    CoachName = c.Name,
                    Footballers = c.Footballers
                        .OrderBy(f => f.Name)
                        .Select(f => new ExportFootballerDto
                        {
                            Name = f.Name,
                            Position = f.PositionType.ToString()
                        })
                        .ToArray()
                })
                .ToArray();

            XmlRootAttribute root = new("Coaches");

            StringWriter writer = new(sb);

            XmlSerializerNamespaces ns= new();
            ns.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new(typeof(ExportCoachDto[]), root);

            serializer.Serialize(writer, coaches, ns);

            return sb.ToString().TrimEnd();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                //.AsNoTracking()
                .Where(t => t.TeamsFootballers
                    .Any(tf => tf.Footballer.ContractStartDate >= date))
                .ToArray()
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                        .Where(ft => ft.Footballer.ContractStartDate >= date)
                        .ToArray()
                        .OrderByDescending(ft => ft.Footballer.ContractEndDate)
                        .ThenBy(ft => ft.Footballer.Name)
                        .Select(tf => new
                        {
                            FootballerName = tf.Footballer.Name,
                            ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = tf.Footballer.BestSkillType.ToString(),
                            PositionType = tf.Footballer.PositionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(t => t.Footballers.Length)
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teams, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
