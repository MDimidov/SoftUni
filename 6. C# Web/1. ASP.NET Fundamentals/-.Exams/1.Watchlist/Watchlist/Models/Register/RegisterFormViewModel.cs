#nullable disable

using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.ValidationConstants.User;
using static Watchlist.Common.ErrorMessages;

namespace Watchlist.Models.Register;

public class RegisterFormViewModel
{
    [Required(ErrorMessage = RequiredField)]
    [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength,
        ErrorMessage = RequiredLength)]
    public string UserName { get; set; }


    [Required(ErrorMessage = RequiredField)]
    [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, 
        ErrorMessage = RequiredLength)]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = RequiredField)]
    [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength,
        ErrorMessage = RequiredLength)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare(nameof(Password))]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

}
