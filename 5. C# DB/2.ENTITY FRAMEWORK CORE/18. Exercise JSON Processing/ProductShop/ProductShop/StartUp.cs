using AutoMapper;
using Castle.Core.Internal;
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
        //string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
        //Console.WriteLine(ImportProducts(context, inputJson));

        //Query 3. Import Categories
        //string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
        //Console.WriteLine(ImportCategories(context, inputJson));

        //Query 4. Import Categories and Products
        string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
        Console.WriteLine(ImportCategoryProducts(context, inputJson));
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

    //Query 3. Import Categories
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        ImportCategoryDto[] categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson)!;

        ICollection<Category> categories = new HashSet<Category>();

        foreach (var categoryDto in categoryDtos)
        {
            if (String.IsNullOrEmpty(categoryDto.Name))
            {
                continue;
            }

            categories.Add(mapper.Map<Category>(categoryDto));
        }

        context.Categories.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Count}";
    }

    //Query 4. Import Categories and Products
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        ImportCategoryProductDto[] categoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson)!;

        CategoryProduct[] categoryProducts = mapper.Map<CategoryProduct[]>(categoryProductDtos);

        context.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Length}";
    }
}