namespace VaporStore.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.Data.Models.Interfaces;
    using VaporStore.DataProcessor.ImportDto;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new();

            ImportGameDto[] gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString)!;

            ICollection<Game> validGames = new HashSet<Game>();

            ICollection<Developer> developers = validGames
                .Select(g => g.Developer)
                .ToHashSet();

            ICollection<Genre> genres = validGames
                .Select(g => g.Genre)
                .ToHashSet();

            ICollection<Tag> tags = validGames
                .SelectMany(g => g.GameTags)
                .Select(g => g.Tag)
                .ToHashSet();

            foreach (ImportGameDto gameDto in gameDtos)
            {
                if (!IsValid(gameDto)
                    || !DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out DateTime releaseDate)
                    || gameDto.Price < 0
                    || gameDto.Tags.Length < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Developer developer = CreateModelIfNotExist(developers, gameDto.Developer);
                Genre genre = CreateModelIfNotExist(genres, gameDto.Genre);

                Game game = new()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate,
                    Developer = developer,
                    Genre = genre
                };

                foreach (string tagName in gameDto.Tags)
                {
                    Tag tag = CreateModelIfNotExist(tags, tagName);

                    game.GameTags.Add(new GameTag
                    {
                        Tag = tag
                    });
                }

                validGames.Add(game);
                sb.AppendLine(string.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));
            }

            context.Games.AddRange(validGames);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static T CreateModelIfNotExist<T>(ICollection<T> models, string modelName) where T : IHasName, new()
        {
            T model;
            if (models.Any(d => d.Name == modelName))
            {
                model = models.FirstOrDefault(m => m.Name == modelName)!;
            }
            else
            {
                model = new T()
                {
                    Name = modelName
                };

                models.Add(model);
            }

            return model;
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new();

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString)!;

            ICollection<User> validUsers = new HashSet<User>();

            foreach (ImportUserDto userDto in userDtos)
            {
                if (!IsValid(userDto)
                    || userDto.Cards.Length < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new()
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                bool hasCardError = false;
                foreach (ImportCardDto cardDto in userDto.Cards)
                {
                    
                    if (!IsValid(cardDto)
                        || !Enum.TryParse(cardDto.Type, out CardType cardType))
                    {
                        sb.AppendLine(ErrorMessage);
                        hasCardError = true;
                        break;
                    }

                    user.Cards.Add(new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = cardType
                    });
                }

                if (!hasCardError)
                {
                    validUsers.Add(user);
                    sb.AppendLine(string.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
                }
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
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