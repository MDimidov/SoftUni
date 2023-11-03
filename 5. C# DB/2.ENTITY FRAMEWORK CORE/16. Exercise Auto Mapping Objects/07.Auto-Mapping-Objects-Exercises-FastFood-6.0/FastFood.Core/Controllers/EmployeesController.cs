namespace FastFood.Web.Controllers
{
    using System;
    using AutoMapper;
    using Data;
    using FastFood.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly IEmployeesService employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            this.employeesService = employeesService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            IEnumerable<RegisterEmployeeViewModel> employees = 
                await employeesService.GetAllAvaliableEmployeesAsync();

            return View(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterEmployeeInputModel model)
        {
            if(!this.ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await this.employeesService.RegisterAsync(model);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<EmployeesAllViewModel> employees =
                await this.employeesService.GetAllAsync();

            return this.View(employees.ToList());
        }
    }
}
