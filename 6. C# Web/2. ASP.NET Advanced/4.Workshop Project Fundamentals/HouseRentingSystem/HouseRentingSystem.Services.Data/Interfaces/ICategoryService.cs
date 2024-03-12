using HouseRentingSystem.Web.ViewModels.Category;

namespace HouseRentingSystem.Services.Data.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoriesAsync();

    Task<bool> ExistByIdAsync(int id);

    Task<IEnumerable<string>> AllCategoryNamesAsync();
}
