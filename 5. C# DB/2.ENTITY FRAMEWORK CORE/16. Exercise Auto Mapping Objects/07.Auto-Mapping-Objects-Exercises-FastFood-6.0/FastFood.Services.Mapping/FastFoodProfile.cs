namespace FastFood.Services.Mapping;

using AutoMapper;
using FastFood.Models;
using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Employees;
using FastFood.Web.ViewModels.Items;
using FastFood.Web.ViewModels.Orders;
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

        //Items
        CreateMap<Category, CreateItemViewModel>()
            .ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Name));

        CreateMap<CreateItemInputModel, Item>();

        CreateMap<Item, ItemsAllViewModel>()
            .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.Name));

        //Employees
        CreateMap<Position, RegisterEmployeeViewModel>()
            .ForMember(d => d.PositionId, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.PositionName, opt => opt.MapFrom(s => s.Name));

        CreateMap<Employee, EmployeesAllViewModel>()
            .ForMember(d => d.Position, opt => opt.MapFrom(s => s.Position.Name));

        CreateMap<RegisterEmployeeInputModel, Employee>();

        //Orders
        CreateMap<CreateOrderInputModel, Order>();
    }
}
