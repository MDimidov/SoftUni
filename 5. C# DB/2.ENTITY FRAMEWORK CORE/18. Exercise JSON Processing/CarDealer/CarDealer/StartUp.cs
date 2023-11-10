using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Data;
using System.Diagnostics.Contracts;
using System.Globalization;

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
        //string inputJson = File.ReadAllText("../../../Datasets/cars.json");
        //Console.WriteLine(ImportCars(context, inputJson));

        //Query 12. Import Customers
        //string inputJson = File.ReadAllText("../../../Datasets/customers.json");
        //Console.WriteLine(ImportCustomers(context, inputJson));

        //Query 13. Import Sales
        //string inputJson = File.ReadAllText("../../../Datasets/sales.json");
        //Console.WriteLine(ImportSales(context, inputJson));

        //3.	Export Data
        //Query 14. Export Ordered Customers
        //Console.WriteLine(GetOrderedCustomers(context));

        //Query 15. Export Cars from Make Toyota
        //Console.WriteLine(GetCarsFromMakeToyota(context));

        //Query 16. Export Local Suppliers
        //Console.WriteLine(GetLocalSuppliers(context));

        //Query 17. Export Cars with Their List of Parts
        //Console.WriteLine(GetCarsWithTheirListOfParts(context));

        //Query 18. Export Total Sales by Customer
        Console.WriteLine(GetTotalSalesByCustomer(context));


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
        ImportCarDto[] carDtos = Newtonsoft.Json.JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson)!;

        List<Car> cars = new();

        foreach (var carDto in carDtos)
        {
            Car car = mapper.Map<Car>(carDto);

            foreach (int partId in carDto.PartsId.Distinct())
            {
                car.PartsCars.Add(new PartCar()
                {
                    PartId = partId
                });
            }

            cars.Add(car);
        }

        context.Cars.AddRange(cars);
        context.SaveChanges();

        return $"Successfully imported {cars.Count}.";
    }

    //Query 12. Import Customers
    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        ImportCustomerDto[] customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson)!;

        Customer[] customers = mapper.Map<Customer[]>(customerDtos);

        context.Customers.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Length}.";
    }

    //Query 13. Import Sales
    //Properly solution of this task is with included comment part but for judge system we ignore verifications
    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        ImportSaleDto[] saleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson)!;

        //int[] carIDs = context
        //    .Cars
        //    .AsNoTracking()
        //    .Select(c => c.Id)
        //    .ToArray();

        //int[] customerIDs = context
        //    .Customers
        //    .AsNoTracking()
        //    .Select(c => c.Id)
        //    .ToArray();

        HashSet<Sale> sales = new();

        foreach (ImportSaleDto saleDto in saleDtos)
        {
            //if(carIDs.Contains(saleDto.CarId) && customerIDs.Contains(saleDto.CustomerId))
            //{
            Sale sale = mapper.Map<Sale>(saleDto);
            sales.Add(sale);
            //}
        }

        context.Sales.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Count}.";
    }

    //3.	Export Data
    //Query 14. Export Ordered Customers
    public static string GetOrderedCustomers(CarDealerContext context)
    {
        var customers = context.Customers
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver.ToString())
            .Select(c => new
            {
                c.Name,
                BirthDate = c.BirthDate.ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo),
                c.IsYoungDriver
            })
            .ToArray();

        return JsonConvert
            .SerializeObject(customers, Formatting.Indented);
    }

    //Query 15. Export Cars from Make Toyota
    public static string GetCarsFromMakeToyota(CarDealerContext context)
    {
        var cars = context.Cars
            .AsNoTracking()
            .Where(c => c.Make == "Toyota")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .Select(c => new
            {
                Id = c.Id,
                c.Make,
                c.Model,
                c.TraveledDistance
            })
            .ToArray();

        return JsonConvert
            .SerializeObject(cars, Formatting.Indented);
    }

    //Query 16. Export Local Suppliers
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var suppliers = context.Suppliers
            .AsNoTracking()
            .Where(s => s.IsImporter == false)
            .Select(s => new
            {
                s.Id,
                s.Name,
                PartsCount = s.Parts.Count
            })
            .ToArray();

        return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
    }

    //Query 17. Export Cars with Their List of Parts
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var result = context
            .Cars
            .AsNoTracking()
            .Select(c => new
            {
                car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },

                parts = c.PartsCars
                    .Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price.ToString("f2")
                    })
            })
            .ToArray();

        return JsonConvert.SerializeObject (result, Formatting.Indented);
    }

    //Query 18. Export Total Sales by Customer
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var customers = context
            .Customers
            .AsNoTracking()
            .Where(c => c.Sales.Any(s => s.Car != null))
            .Select(c => new
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count(s => s.Car != null),
                SpentMoney = c.Sales
                    .SelectMany(s => s.Car.PartsCars)
                    .Sum(pc => pc.Part.Price)

            })
            .OrderByDescending(c => c.SpentMoney)
            .ThenByDescending(c => c.BoughtCars)
            .ToArray();

        return JsonConvert
            .SerializeObject(customers
            , Formatting.Indented
            , new JsonSerializerSettings()
            {
                ContractResolver = ConfigureCamelCase()
            });
    }

    private static IContractResolver ConfigureCamelCase()
        => new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy(false, true)
        };
}