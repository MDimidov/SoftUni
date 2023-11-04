using MusicHub.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;

public class Producer
{
    public Producer()
    {
        Albums = new HashSet<Album>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstraints.ProducerNameMaxLength)]
    public string Name { get; set; } = null!;

    public string? Pseudonym { get; set; }

    //[MaxLength(ValidationConstraints.ProducerPhoneNumberMaxLength)]
    public string? PhoneNumber  { get; set; }

    public virtual ICollection<Album> Albums { get; set; }

}
