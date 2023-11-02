using FastFood.Web.ViewModels.Categories;

namespace FastFood.Services.Data.Interfaces;

public interface ICategoryService
{
    //Task CreateAsync(CategoryAllViewModel inputModel);
    Task CreateAsync(CreateCategoryInputModel model);
    Task <IEnumerable<CategoryAllViewModel>> GetAllAsync();
}
