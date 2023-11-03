using ProductShop.Data;

namespace ProductShop;

public class StartUp
{
    static void Main(string[] args)
    {
        ProductShopContext context = new ProductShopContext();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}