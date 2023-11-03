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



        string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
        Console.WriteLine(ImportUsers(context, inputJson));

    }

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
}