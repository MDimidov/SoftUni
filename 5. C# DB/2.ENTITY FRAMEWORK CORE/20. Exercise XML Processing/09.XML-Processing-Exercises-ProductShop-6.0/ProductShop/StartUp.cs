using AutoMapper;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop;

public class StartUp
{
    private static IMapper mapper = new Mapper(
        new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<ProductShopProfile>();
    }));

    public static void Main()
    {
        using ProductShopContext context = new();

        // 2.Import Data
        //Query 1. Import Users
        string inputXml = File.ReadAllText("../../../Datasets/users.xml");
        Console.WriteLine(ImportUsers(context, inputXml));

    }

    // 2.Import Data
    //Query 1. Import Users
    public static string ImportUsers(ProductShopContext context, string inputXml)
    {
        ImportUserDto[] importUserDtos = new XmlHelper()
            .Deserialize<ImportUserDto[]>(inputXml, "Users");

        User[] validUsers = mapper.Map<User[]>(importUserDtos);

        context.Users.AddRange(validUsers);
        context.SaveChanges();

        return $"Successfully imported {validUsers.Length}";
    }
}