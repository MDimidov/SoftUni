using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
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

    public async Task<IEnumerable<AllCategoriesViewModel>> AllCategoriesForListAsync()
        => await dbContext
        .Categories
        .AsNoTracking()
        .Select(c => new AllCategoriesViewModel
        {
            Id = c.Id,
            Name = c.Name,
        })
        .ToArrayAsync();

	public async Task<IEnumerable<string>> AllCategoryNamesAsync()
	    => await dbContext
        .Categories
        .AsNoTracking()
        .Select (c => c.Name)
        .ToArrayAsync();

	public async Task<bool> ExistByIdAsync(int id)
        => await dbContext
        .Categories
        .AnyAsync(c => c.Id == id);

    public async Task<CategoryDetailsViewModel> GetDetailsByIdAsync(int id)
    {
        Category category = await dbContext
            .Categories
            .AsNoTracking()
            .FirstAsync(c => c.Id == id);

        return new CategoryDetailsViewModel
        {
            Id = category.Id,
            Name = category.Name,
        };
    }
}
