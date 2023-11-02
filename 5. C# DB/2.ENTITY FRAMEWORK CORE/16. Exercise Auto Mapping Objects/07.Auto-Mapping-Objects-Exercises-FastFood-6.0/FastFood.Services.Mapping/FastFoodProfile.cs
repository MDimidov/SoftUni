namespace FastFood.Services.Mapping;

using AutoMapper;
using FastFood.Models;
using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Positions;

public class FastFoodProfile : Profile
{
    public FastFoodProfile()
    {
        //Positions
        CreateMap<CreatePositionInputModel, Position>()
            .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

        CreateMap<Position, PositionsAllViewModel>()
            .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

        //Category
        CreateMap<CreateCategoryInputModel, Category>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.CategoryName));

        CreateMap<Category, CategoryAllViewModel>();

    }
}
