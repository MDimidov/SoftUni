using HouseRentingSystem.Web.ViewModels.Category;

namespace HouseRentingSystem.Services.Data.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoriesAsync();

    Task<IEnumerable<AllCategoriesViewModel>> AllCategoriesForListAsync();

    Task<bool> ExistByIdAsync(int id);

    Task<IEnumerable<string>> AllCategoryNamesAsync();  

    Task<CategoryDetailsViewModel> GetDetailsByIdAsync(int id);
}
