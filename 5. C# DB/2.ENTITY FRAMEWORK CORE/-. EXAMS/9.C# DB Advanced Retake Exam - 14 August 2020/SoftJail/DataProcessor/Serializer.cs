namespace SoftJail.DataProcessor
{
    using CarDealer.Utilities;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ExportDto;
    using System.Globalization;
    using System.Text.Json.Nodes;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisonersByCells = context.Prisoners
                .AsNoTracking()
                .Where(p => ids.Contains(p.Id))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .OrderBy(po => po.Officer.FullName)
                        .Select(po => new
                        {
                            OfficerName = po.Officer.FullName,
                            Department = po.Officer.Department.Name
                        })
                        .ToArray(),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers
                        .Sum(po => po.Officer.Salary), 2)
                })
                .ToArray();

            return JsonConvert.SerializeObject(prisonersByCells, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] prisonersFullNames = prisonersNames.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var prisonersInbox = context.Prisoners
                .AsNoTracking()
                .Where(p => prisonersFullNames.Contains(p.FullName))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .Select(p => new ExportPrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                        .Select(m => new EportMailDto
                        {
                            Description = string.Join("", m.Description.Reverse())
                        })
                        .ToArray()
                })
                .ToArray();

            return new XmlHelper()
                .Serialize(prisonersInbox, "Prisoners");
        }
    }
}