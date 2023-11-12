using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace CarDealer;

public class StartUp
{
    private static IMapper mapper = new Mapper (new MapperConfiguration(cfg =>
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
        string inputXml = File.ReadAllText("../../../Datasets/parts.xml");
        Console.WriteLine(ImportParts(context, inputXml));
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

        foreach(var partDto in partsDtos)
        {
            if(suppliers.Contains(partDto.SupplierId))
            {
                Part part = mapper.Map<Part>(partDto);
                parts.Add(part);
            }
        }

        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Count}";
    }
}