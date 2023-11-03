using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Data.Interfaces;
using FastFood.Web.ViewModels.Items;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Services.Data;

public class ItemsService : IItemsService
{
    private readonly IMapper mapper;
    private readonly FastFoodContext context;

    public ItemsService(IMapper mapper, FastFoodContext context)
    {
        this.mapper = mapper;
        this.context = context;
    }

    public async Task CreateAsync(CreateItemInputModel model)
    {
        Item item = this.mapper.Map<Item>(model);

        await this.context.Items.AddAsync(item);
        await this.context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ItemsAllViewModel>> GetAllAsync()
        => await this.context
        .Items
        .ProjectTo<ItemsAllViewModel>(this.mapper.ConfigurationProvider)
        .ToArrayAsync();

    public async Task<IEnumerable<CreateItemViewModel>> GetAllAvaliableCategoriesAsync()
        => await this.context
        .Categories
        .ProjectTo<CreateItemViewModel>(this.mapper.ConfigurationProvider)
        .ToArrayAsync();
}
