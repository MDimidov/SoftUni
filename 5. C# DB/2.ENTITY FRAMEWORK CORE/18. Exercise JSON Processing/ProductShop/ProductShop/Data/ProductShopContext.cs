using Microsoft.EntityFrameworkCore;
using ProductShop.Common;
using ProductShop.Models;

namespace ProductShop.Data;

public class ProductShopContext : DbContext
{
    public ProductShopContext()
    {
    }

    public ProductShopContext(DbContextOptions options)
       : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; } = null!;

    public virtual DbSet<CategoryProduct> CategoriesProducts { get; set; } = null!;

    public virtual DbSet<Product> Products { get; set; } = null!;

    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(DbConfig.ConnectionString)
                .UseLazyLoadingProxies();
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryProduct>(entity => 
        {
            entity.HasKey(cp => new
            {
                cp.CategoryId,
                cp.ProductId
            });
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasOne(p => p.Seller)
            .WithMany(s => s.SoldProducts)
            .HasForeignKey(p => p.SellerId)
            .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(p => p.Buyer)
            .WithMany(b => b.BoughtProducts)
            .HasForeignKey(p => p.BuyerId)
            .OnDelete(DeleteBehavior.NoAction);
        });
    }
}
