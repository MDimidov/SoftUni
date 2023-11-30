namespace SoftJail.DataProcessor
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
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
            throw new NotImplementedException();
        }
    }
}