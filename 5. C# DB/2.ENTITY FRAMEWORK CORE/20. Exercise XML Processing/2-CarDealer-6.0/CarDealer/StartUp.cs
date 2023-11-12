using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
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
        string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
        Console.WriteLine(ImportSuppliers(context, inputXml));
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
}