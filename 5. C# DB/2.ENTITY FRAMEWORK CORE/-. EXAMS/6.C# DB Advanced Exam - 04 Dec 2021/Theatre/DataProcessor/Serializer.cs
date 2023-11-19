namespace Theatre.DataProcessor
{
    using CarDealer.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Xml.Linq;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .AsNoTracking()
                .Where(t => t.NumberOfHalls >= numbersOfHalls
                        && t.Tickets.Count >= 20)
                .OrderByDescending(t => t.NumberOfHalls)
                .ThenBy(t => t.Name)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .Sum(t => t.Price),
                    Tickets = t.Tickets
                        .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .OrderByDescending(t => t.Price)
                        .Select(t => new
                        {
                            Price = t.Price,
                            RowNumber = t.RowNumber
                        })
                        .ToArray()
                })
                .ToArray();

                return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            ExportPlayDto[] playDtos = context.Plays
                .Where(p => p.Rating <= raiting)
                .ToArray()
                .Select(p => new ExportPlayDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0.0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(c => c.IsMainCharacter)
                        .OrderByDescending(c => c.FullName)
                        .Select(c => new ExportActorDto
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            return new XmlHelper().Serialize(playDtos, "Plays");
        }
    }
}
