using _3.TextSplitterApp.Models;
using _3.TextSplitterApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _3.TextSplitterApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(TextViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Split(TextViewModel model)
        {
            //if (string.IsNullOrWhiteSpace(model.Text))
            //{
            //    return RedirectToAction("Index", String.Empty);
            //}

            string[] splitTextArr = model.Text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            model.SplitText = string.Join(Environment.NewLine, splitTextArr);

            return RedirectToAction("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
