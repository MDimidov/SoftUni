using AutoMapper;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Data.Interfaces;
using FastFood.Web.ViewModels.Orders;

namespace FastFood.Services.Data;

public class OrdersService : IOrdersService
{
    private readonly IMapper mapper;
    private readonly FastFoodContext context;

    public OrdersService(IMapper mapper, FastFoodContext context)
    {
        this.mapper = mapper;
        this.context = context;
    }

    public async Task CreateAsync(CreateOrderInputModel model)
    {
        Order order = this.mapper.Map<Order>(model);

        await this.context.AddAsync(order);
        await this.context.SaveChangesAsync();
    }
}
