using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.Text;
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
        //string inputXml = File.ReadAllText("../../../Datasets/users.xml");
        //Console.WriteLine(ImportUsers(context, inputXml));

        //Query 2. Import Products
        //string inputXml = File.ReadAllText("../../../Datasets/products.xml");
        //Console.WriteLine(ImportProducts(context, inputXml));

        //Query 3. Import Categories
        //string inputXml = File.ReadAllText("../../../Datasets/categories.xml");
        //Console.WriteLine(ImportCategories(context, inputXml));

        //Query 4. Import Categories and Products
        //string inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");
        //Console.WriteLine(ImportCategoryProducts(context, inputXml));

        //3.	Query and Export Data
        //Query 5. Export Products In Range
        //Console.WriteLine(GetProductsInRange(context));

        //Query 6. Export Sold Products
        //Console.WriteLine(GetSoldProducts(context));

        //Query 7. Export Categories By Products Count
        Console.WriteLine(GetCategoriesByProductsCount(context));

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

    //Query 2. Import Products
    public static string ImportProducts(ProductShopContext context, string inputXml)
    {
        ImportProductDto[] productDtos = new XmlHelper()
            .Deserialize<ImportProductDto[]>(inputXml, "Products");

        Product[] products = mapper.Map<Product[]>(productDtos);

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Length}";
    }

    //Query 3. Import Categories
    public static string ImportCategories(ProductShopContext context, string inputXml)
    {
        ImportCategoryDto[] categoryDtos = new XmlHelper()
            .Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

        Category[] categories = mapper.Map<Category[]>(categoryDtos);

        context.Categories.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Length}";
    }

    //Query 4. Import Categories and Products
    public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
    {
        ImportCategoryProductDto[] categoryProductDtos = new XmlHelper()
            .Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

        CategoryProduct[] categoryProducts = mapper
            .Map<CategoryProduct[]>(categoryProductDtos);

        context.CategoryProducts.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Length}";
    }

    //3.	Query and Export Data
    //Query 5. Export Products In Range
    public static string GetProductsInRange(ProductShopContext context)
    {
        ExportProductDto[] products = context
            .Products
            .AsNoTracking()
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Take(10)
            .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
            .ToArray();

        return new XmlHelper()
            .Serialize(products, "Products");
    }

    //Query 6. Export Sold Products
    public static string GetSoldProducts(ProductShopContext context)
    {
        var soldProducts = context
            .Users
            .AsNoTracking()
            .Where(u => u.ProductsSold.Any())
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Take(5)
            .ProjectTo<ExportUserDto>(mapper.ConfigurationProvider)
            .ToArray();

        return new XmlHelper()
            .Serialize(soldProducts, "Users");
    }

    //Query 7. Export Categories By Products Count
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context
            .Categories
            .AsNoTracking()
            .ProjectTo<ExportCategoryDto>(mapper.ConfigurationProvider)
            .OrderByDescending(c => c.Count)
            .ThenBy(c => c.TotalRevenue)
            .ToArray();

        return new XmlHelper()
            .Serialize(categories, "Categories");
    }
}