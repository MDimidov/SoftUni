using FastFood.Data.Config;
using Microsoft.EntityFrameworkCore;
using FastFood.Models;

namespace FastFood.Data;

public class FastFoodContext : DbContext
{
    public FastFoodContext()
    {

    }

    public FastFoodContext(DbContextOptions<FastFoodContext> options)
    : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<OrderItem> OrderItems { get; set; } = null!;

    public DbSet<Position> Positions { get; set; } = null!;

    //This will be not use in WEB layer. Only will be used in test layer.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(ConnectionConfig.ConnectionString)
                .UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.ItemId });

        builder.Entity<Position>()
            .HasAlternateKey(p => p.Name);

        builder.Entity<Item>()
            .HasAlternateKey(i => i.Name);
    }
}
