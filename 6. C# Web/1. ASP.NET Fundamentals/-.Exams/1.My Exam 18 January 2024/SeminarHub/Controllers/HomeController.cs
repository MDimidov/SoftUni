using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeminarHub.Models;
using System.Diagnostics;

namespace SeminarHub.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //If the user is loged int redirect to Seminar/All
            if(User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Seminar");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}