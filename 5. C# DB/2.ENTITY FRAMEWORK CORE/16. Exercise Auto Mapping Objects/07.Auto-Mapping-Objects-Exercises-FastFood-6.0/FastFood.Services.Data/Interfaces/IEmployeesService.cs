using FastFood.Web.ViewModels.Employees;

namespace FastFood.Services.Data.Interfaces;

public interface IEmployeesService
{
    Task RegisterAsync(RegisterEmployeeInputModel model);
    Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync();

    Task<IEnumerable<RegisterEmployeeViewModel>> GetAllAvaliableEmployeesAsync();
}
