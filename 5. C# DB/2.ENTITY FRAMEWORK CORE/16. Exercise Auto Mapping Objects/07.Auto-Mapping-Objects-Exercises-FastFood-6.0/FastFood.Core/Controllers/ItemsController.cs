namespace FastFood.Web.Controllers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly IItemsService itemsService;

        public ItemsController(IItemsService itemsService)
        {
           this.itemsService = itemsService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<CreateItemViewModel> avaliableCategories =
                await this.itemsService.GetAllAvaliableCategoriesAsync();

            return this.View(avaliableCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if(!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.itemsService.CreateAsync(model);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<ItemsAllViewModel> items = 
                await this.itemsService.GetAllAsync();

            return this.View(items.ToList());
        }
    }
}
