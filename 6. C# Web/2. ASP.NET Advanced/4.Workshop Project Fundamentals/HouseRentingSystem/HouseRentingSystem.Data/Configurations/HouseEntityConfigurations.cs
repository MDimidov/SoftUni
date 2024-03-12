using HouseRentingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Data.Configurations;

public class HouseEntityConfigurations : IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder
            .Property(h => h.CreatedOn)
            .HasDefaultValueSql("GETDATE()");

        builder
            .Property(h => h.isActive)
            .HasDefaultValue(true);

        builder
            .HasOne(h => h.Category)
            .WithMany(c => c.Houses)
            .HasForeignKey(h => h.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(h => h.Agent)
            .WithMany(a => a.Houses)
            .HasForeignKey(h => h.AgentId)
            .OnDelete(DeleteBehavior.Restrict);

        //builder
        //    .HasOne(h => h.Renter)
        //    .WithMany(r => r.Houses)
        //    .HasForeignKey(h => h.RenterId)
        //    .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasData(GenerateHouses());

    }

    private House[] GenerateHouses()
    {
        ICollection<House> houses = new HashSet<House>();

        House house;

        house = new House()
        {
            Title = "Big House Marina",
            Address = "North London, UK (near the border)",
            Description = "A big house for your whole family. Don't miss to buy a house with three bedrooms.",
            ImageUrl = "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg",
            PricePerMonth = 2100.00M,
            CategoryId = 3,
            AgentId = Guid.Parse("A954C79E-446D-472B-9250-B2C033693EC9"),
            RenterId = Guid.Parse("0D77D61C-5C5E-447A-327A-08DC37A975D9")
        };
        houses.Add(house);

        house = new House()
        {
            Title = "Family House Comfort",
            Address = "Near the Sea Garden in Burgas, Bulgaria",
            Description = "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.",
            ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1",
            PricePerMonth = 1200.00M,
            CategoryId = 2,
            AgentId = Guid.Parse("A954C79E-446D-472B-9250-B2C033693EC9")
        };
        houses.Add(house);

        house = new House()
        {
            Title = "Grand House",
            Address = "Boyana Neighbourhood, Sofia, Bulgaria",
            Description = "This luxurious house is everything you will need. It is just excellent.",
            ImageUrl = "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg",
            PricePerMonth = 2000.00M,
            CategoryId = 2,
            AgentId = Guid.Parse("A954C79E-446D-472B-9250-B2C033693EC9")
        };
        houses.Add(house);

        return houses.ToArray();
    }
}
