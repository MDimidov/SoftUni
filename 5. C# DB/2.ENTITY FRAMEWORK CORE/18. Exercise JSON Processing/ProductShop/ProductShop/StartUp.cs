using AutoMapper;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
        //string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
        //Console.WriteLine(ImportCategoryProducts(context, inputJson));

        //2.	Export Data
        //Query 5. Export Products in Range
        //Console.WriteLine(GetProductsInRange(context));

        //Query 6. Export Sold Products
        //Console.WriteLine(GetSoldProducts(context));

        //Query 7. Export Categories by Products Count
        //Console.WriteLine(GetCategoriesByProductsCount(context));

        //Query 8. Export Users and Products
        Console.WriteLine(GetUsersWithProducts(context));

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

    //2.	Export Data
    //Query 5. Export Products in Range
    public static string GetProductsInRange(ProductShopContext context)
    {
        IContractResolver contractResolver = ConfigureCamelCasing();
        var products = context.Products
            .AsNoTracking()
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Select(p => new
            {
                Name = p.Name,
                Price = p.Price,
                Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
            })
            .ToArray();

        return JsonConvert.SerializeObject(products,
            Formatting.Indented,
            new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });
    }

    //Query 6. Export Sold Products
    public static string GetSoldProducts(ProductShopContext context)
    {
        IContractResolver contractResolver = ConfigureCamelCasing();

        var products = context.Users
            .AsNoTracking()
            .Where(u => u.SoldProducts.Any(p => p.Buyer != null))
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                SoldProducts = u.SoldProducts
                    .Where(sp => sp.Buyer != null)
                    .Select(sp => new
                    {
                        sp.Name,
                        sp.Price,
                        BuyerFirstName = sp.Buyer!.FirstName,
                        BuyerLastName = sp.Buyer!.LastName
                    })
                    .ToArray()
            })
            .ToArray();

        return JsonConvert.SerializeObject(products,
            Formatting.Indented,
            new JsonSerializerSettings()
            {
                ContractResolver = contractResolver
            });
    }

    //Query 7. Export Categories by Products Count
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        IContractResolver contractResolver = ConfigureCamelCasing();

        var categories = context.Categories
            .AsNoTracking()
            .OrderByDescending(c => c.CategoriesProducts.Count())
            .Select(c => new
            {
                Category = c.Name,
                ProductsCount = c.CategoriesProducts.Count(),
                AveragePrice = c.CategoriesProducts.Average(cp => cp.Product.Price).ToString("f2"),
                TotalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price).ToString("f2")
            })
            .ToArray();

        return JsonConvert.SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings
        {
            ContractResolver = contractResolver
        });
    }

    //Query 8. Export Users and Products
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        IContractResolver contractResolver = ConfigureCamelCasing();

        var users = context.Users
            .AsNoTracking()
            .Where(u => u.SoldProducts.Any(sp => sp.Buyer != null))
            .OrderByDescending(u => u.SoldProducts.Count)
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.Age,
                SoldProducts = new
                {
                    Count = u.SoldProducts.Count(p => p.Buyer != null),
                    Products = u.SoldProducts
                            .Where(p => p.Buyer != null)
                            .Select(sp => new
                            {
                                sp.Name,
                                sp.Price
                            })
                            .ToArray()
                }
            })
            .ToArray();

        var result = new
        {
            UsersCount = users.Length,
            Users = users
        };

        return JsonConvert.SerializeObject(result,
            Formatting.Indented,
            new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore
            });
    }

    public static IContractResolver ConfigureCamelCasing()
        => new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy(false, true)
        };
}