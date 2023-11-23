namespace TeisterMask.DataProcessor
{
    using CarDealer.Utilities;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            ExportProjectDto[] projectsWithTasks = context
                .Projects
                .AsNoTracking()
                .OrderByDescending(p => p.Tasks.Count)
                .ThenBy(p => p.Name)
                .Where(p => p.Tasks.Any())
                .Select(p => new ExportProjectDto
                {
                    TasksCount = p.Tasks.Count(),
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks
                        .OrderBy(t => t.Name)
                        .Select(t => new ExportTaskDto
                        {
                            Name = t.Name,
                            Label = t.LabelType.ToString()
                        })
                        .ToArray()
                })
                .ToArray();

            return new XmlHelper().Serialize(projectsWithTasks, "Projects");
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var mostBusiestEmployees = context
                .Employees
                .AsNoTracking()
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(et => et.Task.OpenDate >= date)
                        .OrderByDescending(et => et.Task.DueDate)
                        .ThenBy(et => et.Task.Name)
                        .Select(et => new
                        {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(mostBusiestEmployees, Formatting.Indented);
        }
    }
}