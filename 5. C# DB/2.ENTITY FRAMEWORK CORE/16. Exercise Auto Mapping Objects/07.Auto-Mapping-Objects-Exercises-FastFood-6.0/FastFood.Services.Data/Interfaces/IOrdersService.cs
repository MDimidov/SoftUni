using FastFood.Web.ViewModels.Orders;

namespace FastFood.Services.Data.Interfaces;

public interface IOrdersService
{
    Task CreateAsync(CreateOrderInputModel model);
}
