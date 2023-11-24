namespace VaporStore.DataProcessor;

using CarDealer.Utilities;
using Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.ExportDto;

public static class Serializer
{
    public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
    {
        var gamesByGenres = context.Genres
            .Where(gn => genreNames.Contains(gn.Name))
            .ToArray()
            .Select(gn => new
            {
                Id = gn.Id,
                Genre = gn.Name,
                Games = gn.Games
                    .Where(gm => gm.Purchases.Any())
                    .OrderByDescending(gm => gm.Purchases.Count)
                    .ThenBy(gm => gm.Id)
                    .Select(gm => new
                    {
                        Id = gm.Id,
                        Title = gm.Name,
                        Developer = gm.Developer.Name,
                        Tags = string.Join(", ", gm.GameTags
                            .Select(gt => gt.Tag.Name)
                            .ToArray()),
                        Players = gm.Purchases.Count
                    })
                    .ToArray(),
                TotalPlayers = gn.Games.Sum(gm => gm.Purchases.Count)
            })
            .OrderByDescending(gn => gn.TotalPlayers)
            .ThenBy(gm => gm.Id)
            .ToArray();

        return JsonConvert.SerializeObject(gamesByGenres, Formatting.Indented);
    }

    public static string ExportUserPurchasesByType(VaporStoreDbContext context, string purchaseType)
    {
        var userPurchasesByType = context.Users
            .Where(u => u.Cards.Any(c => c.Purchases.Any()))
            .ToArray()
            .Select(u => new ExportUserDto
            {
                Username = u.Username,
                Purchases = u.Cards
                    .SelectMany(c => c.Purchases)
                    .Where(p => p.Type.ToString() == purchaseType)
                    .OrderBy(p => p.Date)
                    .Select(p => new ExportPurchaseDto()
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportGameDto
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                           .ToArray(),
                TotalSpent = u.Cards.Sum(c => c.Purchases
                    .Where(p => p.Type
                        .ToString() == purchaseType)
                    .Sum(p => p.Game.Price))
            })
            .Where(u => u.Purchases.Length > 0)
            .OrderByDescending(u => u.TotalSpent)
            .ThenBy(u => u.Username)
            .ToArray();

        return new XmlHelper()
            .Serialize(userPurchasesByType, "Users");
    }
}