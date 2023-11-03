using FastFood.Web.ViewModels.Items;

namespace FastFood.Services.Data.Interfaces;

public interface IItemsService
{
    Task CreateAsync(CreateItemInputModel model);
    Task<IEnumerable<ItemsAllViewModel>> GetAllAsync();
    Task <IEnumerable<CreateItemViewModel>> GetAllAvaliableCategoriesAsync ();
}
