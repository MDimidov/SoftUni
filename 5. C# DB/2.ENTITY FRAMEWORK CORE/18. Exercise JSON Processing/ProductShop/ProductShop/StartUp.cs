using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop;

public class StartUp
{
    static void Main(string[] args)
    {
        ProductShopContext context = new ProductShopContext();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

    }
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        User user = new User();
    }
}