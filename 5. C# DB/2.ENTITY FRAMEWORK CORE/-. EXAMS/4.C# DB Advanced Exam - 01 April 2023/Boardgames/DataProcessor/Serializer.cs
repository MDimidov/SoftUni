namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using CarDealer.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Xml.Linq;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            ExportCreatorDto[] creatorsWhitGames = context.Creators
                .Where(c => c.Boardgames.Any())
                .ToArray()
                .Select(c => new ExportCreatorDto
                {
                    BoardgamesCount = c.Boardgames.Count(),
                    CreatorName = $"{c.FirstName} {c.LastName}",
                    Boardgames = c.Boardgames
                        .OrderBy(b => b.Name)
                        .Select(b => new ExportBoardgameDto
                        {
                            BoardgameName = b.Name,
                            BoardgameYearPublished = b.YearPublished
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.CreatorName)
                .ToArray();

            return new XmlHelper().Serialize(creatorsWhitGames, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellerWithMostGames = context.Sellers
                .AsNoTracking()
                .Where(s => s.BoardgamesSellers
                    .Any(bs => bs.Boardgame.YearPublished >= year
                           && bs.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(bs => bs.Boardgame.YearPublished >= year
                            && bs.Boardgame.Rating <= rating)
                        .OrderByDescending(bs => bs.Boardgame.Rating)
                        .ThenBy(bs => bs.Boardgame.Name)
                        .Select(bs => new
                        {
                            Name = bs.Boardgame.Name,
                            Rating = bs.Boardgame.Rating,
                            Mechanics = bs.Boardgame.Mechanics,
                            Category = bs.Boardgame.CategoryType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellerWithMostGames, Formatting.Indented);
        }
    }
}