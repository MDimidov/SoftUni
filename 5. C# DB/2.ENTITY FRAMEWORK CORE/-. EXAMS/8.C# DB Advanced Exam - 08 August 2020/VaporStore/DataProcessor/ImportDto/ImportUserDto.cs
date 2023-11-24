using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.DataProcessor.ImportDto;

public class ImportUserDto
{
    [Required]
    [RegularExpression(ValidationConstants.UserFullNameRegex)]
    public string FullName { get; set; } = null!;

    [Required]
    [MinLength(ValidationConstants.UserUsernameMinLength)]
    [MaxLength(ValidationConstants.UserUsernameMaxLength)]
    public string Username { get; set;} = null!;

    [Required]
    //[EmailAddress]
    public string Email { get; set;} = null!;

    [Required]
    [Range(ValidationConstants.UserAgeMinRange, ValidationConstants.UserAgeMaxRange)]
    public int Age { get; set;}

    [Required]
    public ImportCardDto[] Cards = null!;
}
