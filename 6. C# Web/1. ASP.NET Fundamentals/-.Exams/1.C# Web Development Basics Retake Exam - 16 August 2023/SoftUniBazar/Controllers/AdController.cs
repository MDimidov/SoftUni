using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models.Ad;
using SoftUniBazar.Models.Category;
using System.Security.Claims;
using static SoftUniBazar.Common.ErrorMessages;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly BazarDbContext dbContext;
        public AdController(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task <IActionResult> All ()
        {
            var model = await dbContext.Ads
                .AsNoTracking()
                .Select(a => new AdAllViewModel(
                    a.Id,
                    a.Name,
                    a.Description,
                    a.Price,
                    a.Owner.UserName,
                    a.ImageUrl,
                    a.CreatedOn,
                    a.Category.Name))
                .ToArrayAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AdFormViewModel();

            model.Categories = await GetCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormViewModel model)
        {
            var categories = await GetCategoriesAsync();
            if(!categories.Any(c => c.Id == model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), WrongCategory);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Ad ad = new()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                CategoryId = model.CategoryId,
                OwnerId = GetUserId(),
                CreatedOn = DateTime.Now
            };

            await dbContext.Ads.AddAsync(ad);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ad = await dbContext.Ads.FindAsync(id);

            if(ad == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if(ad.OwnerId != userId)
            {
                return Unauthorized();
            }

            AdFormViewModel model = new()
            {
                Name = ad.Name,
                Description = ad.Description,
                Categories = await GetCategoriesAsync(),
                CategoryId = ad.CategoryId,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdFormViewModel model, int id)
        {
            var ad = await dbContext.Ads.FindAsync(id);

            if (ad == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (ad.OwnerId != userId)
            {
                return Unauthorized();
            }

            var categories = await GetCategoriesAsync();

            if(!categories.Any(c => c.Id == model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), WrongCategory); 
            }

            if(!ModelState.IsValid)
            {
                model.Categories = await GetCategoriesAsync();
                return View(model);
            }

            ad.Name = model.Name;
            ad.Description = model.Description;
            ad.CategoryId = model.CategoryId;
            ad.ImageUrl = model.ImageUrl;
            ad.Price = model.Price;

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }


        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var ad = await dbContext.Ads.FindAsync(id);

            if(ad == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var adBuyer = new AdBuyer()
            {
                BuyerId = userId,
                AdId = ad.Id
            };

            if(await dbContext.AdsBuyers.ContainsAsync(adBuyer))
            {
                return RedirectToAction(nameof(All));
            }

            await dbContext.AdsBuyers.AddAsync(adBuyer);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }


        public async Task<IActionResult> Cart()
        {
            string userId = GetUserId();

            var model = await dbContext
                .AdsBuyers
                .AsNoTracking()
                .Where(ab => ab.BuyerId == userId)
                .Select(ab => new AdAllViewModel(
                    ab.AdId,
                    ab.Ad.Name,
                    ab.Ad.Description,
                    ab.Ad.Price,
                    ab.Ad.Owner.UserName,
                    ab.Ad.ImageUrl,
                    ab.Ad.CreatedOn,
                    ab.Ad.Category.Name))
                .ToArrayAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            string userId = GetUserId();

            var adBuyer = await dbContext
                .AdsBuyers
                .Where(ab => ab.AdId == id && ab.BuyerId == userId)
                .FirstOrDefaultAsync();

            if(adBuyer == null)
            {
                return BadRequest();
            }

            dbContext.AdsBuyers.Remove(adBuyer);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }


        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
            => await dbContext
            .Categories
            .AsNoTracking()
            .Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToArrayAsync();
    }
}
