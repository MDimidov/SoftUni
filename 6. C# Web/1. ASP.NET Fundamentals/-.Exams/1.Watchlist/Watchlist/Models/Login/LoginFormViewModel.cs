#nullable disable

using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.ValidationConstants.User;
using static Watchlist.Common.ErrorMessages;

namespace Watchlist.Models.Login;

public class LoginFormViewModel
{
    [Required(ErrorMessage = RequiredField)]
    public string UserName { get; set; }

    [Required(ErrorMessage = RequiredField)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
