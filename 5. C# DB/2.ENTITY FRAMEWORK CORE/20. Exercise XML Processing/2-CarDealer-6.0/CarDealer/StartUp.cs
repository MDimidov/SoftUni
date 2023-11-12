using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using System.Text;
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
        //string inputXml = File.ReadAllText("../../../Datasets/customers.xml");
        //Console.WriteLine(ImportCustomers(context, inputXml));

        //Query 13. Import Sales
        //string inputXml = File.ReadAllText("../../../Datasets/sales.xml");
        //Console.WriteLine(ImportSales(context, inputXml));

        //3.	Query and Export Data
        //Query 14. Export Cars With Distance
        //Console.WriteLine(GetCarsWithDistance(context));

        //Query 15. Export Cars from Make BMW
        //Console.WriteLine(GetCarsFromMakeBmw(context));

        //Query 16. Export Local Suppliers
        Console.WriteLine(GetLocalSuppliers(context));


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

    //Query 13. Import Sales
    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        ImportSaleDto[] saleDtos = new XmlHelper()
            .Deserialize<ImportSaleDto[]>(inputXml, "Sales");

        HashSet<Sale> sales = new();
        int[] carIds = context.Cars
            .AsNoTracking()
            .Select(c => c.Id)
            .ToArray(); 

        foreach(ImportSaleDto saleDto in saleDtos)
        {
            if(carIds.Contains(saleDto.CarId))
            {
                Sale sale = mapper.Map<Sale>(saleDto);
                sales.Add(sale);
            }
        }

        context.Sales.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Count}";
    }

    //3.	Query and Export Data
    //Query 14. Export Cars With Distance
    public static string GetCarsWithDistance(CarDealerContext context)
    {
        ExportCarDto[] cars = context.Cars
            .AsNoTracking()
            .Where(c => c.TraveledDistance > 2_000_000)
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .Take(10)
            .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
            .ToArray();


        return new XmlHelper()
            .Serialize(cars, "cars");
    }

    //Query 15. Export Cars from Make BMW
    public static string GetCarsFromMakeBmw(CarDealerContext context)
    {
        var BMWcars = context.Cars
            .AsNoTracking()
            .Where(c => c.Make.ToUpper() == "BMW")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .ProjectTo<ExportBMWCarDto>(mapper.ConfigurationProvider)
            .ToArray();

        return new XmlHelper()
            .Serialize(BMWcars, "cars");
    }

    //Query 16. Export Local Suppliers
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var localSuppliers = context
            .Suppliers
            .AsNoTracking()
            .Where(s => s.IsImporter == false)
            .ProjectTo<ExportSupplierDto>(mapper.ConfigurationProvider)
            .ToArray();

        return new XmlHelper()
            .Serialize(localSuppliers, "suppliers");
    }
}