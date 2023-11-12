using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop;

public class ProductShopProfile : Profile
{
    public ProductShopProfile()
    {
        // User
        CreateMap<ImportUserDto, User>();

        // Product
        CreateMap<ImportProductDto, Product>();
        CreateMap<Product, ExportProductDto>()
            .ForMember(d => d.BuyerName, 
                        opt => opt.MapFrom( s => $"{s.Buyer.FirstName} {s.Buyer.LastName}"));

        // Categories
        CreateMap<ImportCategoryDto, Category>();

        // CategoryProduct
        CreateMap<ImportCategoryProductDto, CategoryProduct>();
    }
}
