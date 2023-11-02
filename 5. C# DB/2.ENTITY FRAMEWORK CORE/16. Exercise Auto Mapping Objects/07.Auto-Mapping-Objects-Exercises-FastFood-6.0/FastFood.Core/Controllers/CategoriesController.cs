namespace FastFood.Web.Controllers
{
    using System;
    using AutoMapper;
    using Data;
    using FastFood.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await this.categoryService.CreateAsync(model);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<CategoryAllViewModel> categories = 
                await this.categoryService.GetAllAsync();

            return View(categories.ToList());
        }
    }
}
