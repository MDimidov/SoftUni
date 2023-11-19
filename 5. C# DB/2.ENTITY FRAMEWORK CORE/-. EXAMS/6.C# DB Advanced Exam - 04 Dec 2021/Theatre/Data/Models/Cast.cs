using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Theatre.Common;

namespace Theatre.Data.Models;

public class Cast
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.CastFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    public bool IsMainCharacter { get; set; }

    [Required]
    [MaxLength(ValidationConstants.CastPhoneNumberLength)]
    public string PhoneNumber { get; set; } = null!;

    [ForeignKey(nameof(Play))]
    public int PlayId { get; set; }
    public virtual Play Play { get; set; } = null!;
}
