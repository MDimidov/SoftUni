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
        CreateMap<User, ExportUserDto>()
            .IgnoreAllPropertiesWithAnInaccessibleSetter();

        // Product
        CreateMap<ImportProductDto, Product>();
        CreateMap<Product, ExportProductDto>()
            .ForMember(d => d.BuyerName, 
                        opt => opt.MapFrom( s => $"{s.Buyer.FirstName} {s.Buyer.LastName}"));
        CreateMap<Product, ExportProductNamePriceDto>();

        // Categories
        CreateMap<ImportCategoryDto, Category>();

        // CategoryProduct
        CreateMap<ImportCategoryProductDto, CategoryProduct>();
    }
}
