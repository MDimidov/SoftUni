using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop;

public class StartUp
{
    private static IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<ProductShopProfile>();
    }));

    public static void Main(string[] args)
    {
        

        ProductShopContext context = new ProductShopContext();
        //context.Database.EnsureDeleted();
        //context.Database.EnsureCreated();


        //1.	Import Data
        //Query 1.Import Users
        //string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
        //Console.WriteLine(ImportUsers(context, inputJson));

        //Query 2. Import Products
        string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
        Console.WriteLine(ImportProducts(context, inputJson));

    }

    //1.	Import Data
    //Query 1. Import Users
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson)!;

        ICollection<User> validUsers = new HashSet<User>();

        foreach (var userDto in userDtos)
        {
            User user = mapper.Map<User>(userDto);

            validUsers.Add(user);
        }

        context.Users.AddRange(validUsers);
        context.SaveChanges();

        return $"Successfully imported {validUsers.Count}";

    }

    //Query 2. Import Products
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        ImportProductDto[] productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson)!;

        Product[] products = mapper.Map<Product[]>(productDtos);

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Length}";
    }
}