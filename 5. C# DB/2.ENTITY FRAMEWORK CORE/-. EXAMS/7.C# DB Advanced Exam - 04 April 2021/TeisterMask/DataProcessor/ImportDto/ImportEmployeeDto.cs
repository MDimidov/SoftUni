using System.ComponentModel.DataAnnotations;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto;

public class ImportEmployeeDto
{
    [Required]
    [MinLength(ValidationConstants.EmployeeUsernameMinLength)]
    [MaxLength(ValidationConstants.EmployeeUsernameMaxLength)]
    [RegularExpression(ValidationConstants.EmployeeUsernameRegex)]
    public string Username { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [RegularExpression(ValidationConstants.EmployeePhoneRegex)]
    public string Phone { get; set; } = null!;

    public int[] Tasks { get; set; } = null!;
}
