using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

namespace CarDealer;

public class StartUp
{
    private static IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<CarDealerProfile>();
    }));

    public static void Main()
    {
        CarDealerContext context = new();

        //2.	Import Data
        //Query 9. Import Suppliers
        //string inputJson = File.ReadAllText("../../../Datasets/suppliers.json");
        //Console.WriteLine(ImportSuppliers(context, inputJson));

        ////Query 10.Import Parts
        //string inputJson1 = File.ReadAllText("../../../Datasets/parts.json");
        //Console.WriteLine(ImportParts(context, inputJson1));

        //Query 11. Import Cars
        string inputJson = File.ReadAllText("../../../Datasets/cars.json");
        Console.WriteLine(ImportCars(context, inputJson));

    }

    //2.	Import Data
    //Query 9. Import Suppliers
    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        ImportSupplierDto[] supplierDtos = JsonConvert
            .DeserializeObject<ImportSupplierDto[]>(inputJson)!;

        Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDtos);

        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Length}."; ;
    }

    //Query 10. Import Parts
    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        int[] suppliers = context.Suppliers
            .Select(s => s.Id)
            .ToArray();

        HashSet<Part> parts = new();

        ImportPartDto[] partDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson)!;

        foreach (ImportPartDto part in partDtos)
        {
            if (suppliers.Contains(part.SupplierId))
            {
                parts.Add(mapper.Map<Part>(part));
            }
        }

        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Count}.";
    }

    //Query 11. Import Cars
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        ImportCarDto[] carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson)!;

        foreach (var carDto in carDtos)
        {
            Car car = mapper.Map<Car>(carDto);

            context.Cars.Add(car);
            context.SaveChanges();

            foreach (int partId in carDto.PartsId)
            {
                int carId = context.Cars.AsNoTracking().OrderBy(c => c.Id).LastOrDefault()!.Id;
                PartCar partCar = new()
                {
                    CarId = carId,
                    PartId = partId
                };

                if (car.PartsCars.FirstOrDefault(pc => pc.PartId == partId) == null)
                {
                    context.PartsCars.Add(partCar);
                }
            }
        }

        context.SaveChanges();

        return $"Successfully imported {carDtos.Length}.";
    }
}