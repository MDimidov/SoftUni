using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace CarDealer;

public class StartUp
{
    private static IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<CarDealerProfile>();
    }));

    public static void Main()
    {
        using CarDealerContext context = new();

        //2.	Import Data
        //Query 9. Import Suppliers
        //string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
        //Console.WriteLine(ImportSuppliers(context, inputXml));

        //Query 10. Import Parts
        //string inputXml = File.ReadAllText("../../../Datasets/parts.xml");
        //Console.WriteLine(ImportParts(context, inputXml));

        //Query 11. Import Cars
        //string inputXml = File.ReadAllText("../../../Datasets/cars.xml");
        //Console.WriteLine(ImportCars(context, inputXml));

        //Query 12. Import Customers
        string inputXml = File.ReadAllText("../../../Datasets/customers.xml");
        Console.WriteLine(ImportCustomers(context, inputXml));

    }

    //2.	Import Data
    //Query 9. Import Suppliers
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        ImportSupplierDto[] importSupplierDtos = new XmlHelper()
            .Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

        Supplier[] suppliers = mapper
            .Map<Supplier[]>(importSupplierDtos);

        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Length}";
    }

    //Query 10. Import Parts
    public static string ImportParts(CarDealerContext context, string inputXml)
    {
        ImportPartDto[] partsDtos = new XmlHelper()
            .Deserialize<ImportPartDto[]>(inputXml, "Parts");

        int[] suppliers = context.Suppliers
            .AsNoTracking()
            .Select(s => s.Id)
            .ToArray();

        HashSet<Part> parts = new();

        foreach (var partDto in partsDtos)
        {
            if (suppliers.Contains(partDto.SupplierId))
            {
                Part part = mapper.Map<Part>(partDto);
                parts.Add(part);
            }
        }

        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Count}";
    }

    //Query 11. Import Cars
    public static string ImportCars(CarDealerContext context, string inputXml)
    {
        ImportCarDto[] carDtos = new XmlHelper()
            .Deserialize<ImportCarDto[]>(inputXml, "Cars");

        HashSet<Car> cars = new();

        int[] partIds = context
            .Parts
            .AsNoTracking()
            .Select(p => p.Id)
            .ToArray();

        foreach (var carDto in carDtos)
        {
            Car car = mapper.Map<Car>(carDto);
            
            foreach(var part in carDto.Parts.DistinctBy(p => p.PartyId))
            {
                if (partIds.Contains(part.PartyId))
                {
                    car.PartsCars
                        .Add(new PartCar
                        {
                            PartId = part.PartyId
                        });
                }
            }
            
            cars.Add(car);
        }

        context.Cars.AddRange(cars);
        context.SaveChanges();

        return $"Successfully imported {cars.Count}";
    }

    //Query 12. Import Customers
    public static string ImportCustomers(CarDealerContext context, string inputXml)
    {
        ImportCustomerDto[] customerDtos = new XmlHelper()
            .Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

        Customer[] customers = mapper.Map<Customer[]>(customerDtos);

        context.Customers.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Length}";
    }
}