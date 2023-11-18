namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using CarDealer.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new();
            ImportCountryDto[] countryDtos = new XmlHelper()
                .Deserialize<ImportCountryDto[]>(xmlString, "Countries");

            ICollection<Country> validCountries = new HashSet<Country>();
            foreach (var countryDto in countryDtos)
            {
                if (!IsValid(countryDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new()
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize,
                };

                validCountries.Add(country);
                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(validCountries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new();

            ImportManufactureDto[] manufactureDtos = new XmlHelper()
                .Deserialize<ImportManufactureDto[]>(xmlString, "Manufacturers");

            ICollection<Manufacturer> validManufacturers = new HashSet<Manufacturer>();

            foreach (ImportManufactureDto manufacturerDto in manufactureDtos)
            {
                bool isDublicate = validManufacturers
                    .Any(m => m.ManufacturerName == manufacturerDto.ManufacturerName);

                //var uniqueManufacturer = validManufacturers.FirstOrDefault(x => x.ManufacturerName == manufacturerDto.ManufacturerName);

                if (!IsValid(manufacturerDto)
                    || isDublicate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = new()
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded
                };

                string[] townAndCountryNameArr = manufacturerDto.Founded
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .TakeLast(2)
                    .ToArray();

                string townAndCountryName = string.Join(", ", townAndCountryNameArr);

                validManufacturers.Add(manufacturer);
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, townAndCountryName));
            }

            context.Manufacturers.AddRange(validManufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new();

            ImportShellDto[] ShellDtos = new XmlHelper()
                .Deserialize<ImportShellDto[]>(xmlString, "Shells");

            ICollection<Shell> validShells = new HashSet<Shell>();

            foreach (ImportShellDto shellDto in ShellDtos)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new()
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber
                };

                validShells.Add(shell);
                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new();

            var gunsDtos = JsonConvert
                .DeserializeObject<ImportGunDto[]>(jsonString)!;

            ICollection<Gun> validGuns = new HashSet<Gun>();

            int[] manufacturersIds = context.Manufacturers
                .AsNoTracking()
                .Select(m => m.Id)
                .ToArray();

            int[] shellsIds = context.Shells
                .AsNoTracking()
                .Select(s => s.Id)
                .ToArray();

            foreach (var gunDto in gunsDtos)
            {
                if (!IsValid(gunDto)
                    || !manufacturersIds.Contains(gunDto.ManufacturerId)
                    || !shellsIds.Contains(gunDto.ShellId)
                    || !Enum.TryParse<GunType>(gunDto.GunType, out GunType gunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new()
                {
                    ManufacturerId = gunDto.ManufacturerId,
                    GunWeight = gunDto.GunWeight,
                    BarrelLength = gunDto.BarrelLength,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    GunType = gunType,
                    ShellId = gunDto.ShellId,
                };

                foreach(var coutry in gunDto.Countries.DistinctBy(c => c.Id))
                {
                    gun.CountriesGuns.Add(new()
                    {
                        CountryId = coutry.Id,
                        Gun = gun
                    });
                }

                validGuns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType.ToString(), gun.GunWeight, gun.BarrelLength));
            }

            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}