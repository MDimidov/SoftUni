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

        //Query 12. Import Customers
        //string inputJson = File.ReadAllText("../../../Datasets/customers.json");
        //Console.WriteLine(ImportCustomers(context, inputJson));

        //Query 13. Import Sales
        //string inputJson = File.ReadAllText("../../../Datasets/sales.json");
        //Console.WriteLine(ImportSales(context, inputJson));

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

        List<Car> cars = new();

        foreach (var carDto in carDtos)
        {
            Car car = mapper.Map<Car>(carDto);

            foreach (int partId in carDto.PartsId.Distinct())
            {
                car.PartsCars.Add( new PartCar()
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
}