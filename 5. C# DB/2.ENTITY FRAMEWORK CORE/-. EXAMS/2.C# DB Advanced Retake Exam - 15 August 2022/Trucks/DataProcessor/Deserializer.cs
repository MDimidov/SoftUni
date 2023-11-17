namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Nodes;
    using CarDealer.Utilities;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder sb = new();

            ImportDespatcherDto[] despatcherDtos = new XmlHelper()
                .Deserialize<ImportDespatcherDto[]>(xmlString, "Despatchers");

            HashSet<Despatcher> despatchers = new();

            foreach (var despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher despatcher = new()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position
                };

                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    despatcher.Trucks.Add(new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType
                    });
                }

                despatchers.Add(despatcher);
                sb.AppendLine(String.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }

            context.Despatchers.AddRange(despatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new();

            ImportClientDto[] clientDtos = JsonConvert
                .DeserializeObject<ImportClientDto[]>(jsonString)!;

            int[] trucksIds = context.Trucks
                .Select(x => x.Id)
                .ToArray();

            HashSet<Client> clients = new();

            foreach (ImportClientDto clientDto in clientDtos)
            {
                if (!IsValid(clientDto)
                    || string.IsNullOrEmpty(clientDto.Name)
                    || string.IsNullOrEmpty(clientDto.Nationality)
                    || string.IsNullOrEmpty(clientDto.Type)
                    || clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type
                };

                foreach (var truckId in clientDto.Trucks.Distinct())
                {
                    if (!trucksIds.Contains(truckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    client.ClientsTrucks
                        .Add(new ClientTruck()
                        {
                            TruckId = truckId,
                        });
                }

                clients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.Clients.AddRange(clients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}