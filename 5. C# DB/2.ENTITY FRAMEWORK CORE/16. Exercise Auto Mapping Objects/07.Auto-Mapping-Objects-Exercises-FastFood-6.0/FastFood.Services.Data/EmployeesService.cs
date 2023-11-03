using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Data.Interfaces;
using FastFood.Web.ViewModels.Employees;
using FastFood.Services.Mapping;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Services.Data;

public class EmployeesService : IEmployeesService
{
    private readonly IMapper mapper;
    private readonly FastFoodContext context;

    public EmployeesService(IMapper mapper, FastFoodContext context)
    {
        this.mapper = mapper;
        this.context = context;
    }

    public async Task RegisterAsync(RegisterEmployeeInputModel model)
    {
        Employee employee = this.mapper.Map<Employee>(model);

        await this.context.AddAsync(employee);
        await this.context.SaveChangesAsync();
    }

    public async Task<IEnumerable<RegisterEmployeeViewModel>> GetAllAvaliableEmployeesAsync()
        => await context
            .Positions
            .ProjectTo<RegisterEmployeeViewModel>(this.mapper.ConfigurationProvider)
            .ToArrayAsync();


    public async Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync()
        => await this.context
        .Employees
        .ProjectTo<EmployeesAllViewModel>(mapper.ConfigurationProvider)
        .ToArrayAsync();
}
