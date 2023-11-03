using FastFood.Common.EntityConfig;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Employees
{
    public class RegisterEmployeeInputModel
    {
        //[StringLength(ValidationConstants.EmployeeNameMaxLength, MinimumLength = ValidationConstants.EmployeeNameMinLength)]
        [MinLength(ViewModelsValidation.EmployeeNameMinLength)]
        [MaxLength(ViewModelsValidation.EmployeeNameMaxLength)]
        public string Name { get; set; }

        public int Age { get; set; }

        public int PositionId { get; set; }

        //public string PositionName { get; set; }
        
        //[StringLength(ValidationConstants.EmployeeAddressMaxLength, MinimumLength = 3)]
        [MinLength(ViewModelsValidation.EmployeeAddressMinLength)]
        [MaxLength(ViewModelsValidation.EmployeeAddressMaxLength)]
        public string Address { get; set; } = null!;
    }
}
