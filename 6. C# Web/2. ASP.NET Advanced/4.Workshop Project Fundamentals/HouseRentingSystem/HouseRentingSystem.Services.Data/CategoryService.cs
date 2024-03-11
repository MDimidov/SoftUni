using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Data;

public class CategoryService : ICategoryService
{
    private readonly HouseRentingDbContext dbContext;

    public CategoryService(HouseRentingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoriesAsync()
        => await dbContext
            .Categories
            .AsNoTracking()
            .Select(c => new HouseSelectCategoryFormModel
            {
                Id = c.Id,
                Name = c.Name,
            })
            .ToArrayAsync();
}
