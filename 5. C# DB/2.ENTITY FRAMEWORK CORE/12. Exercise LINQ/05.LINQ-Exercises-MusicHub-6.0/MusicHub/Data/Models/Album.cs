using MusicHub.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models;

public class Album
{
    public Album()
    {
        Songs = new HashSet<Song>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstraints.AlbumNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public DateTime ReleaseDate { get; set; }

    [NotMapped]
    public decimal Price ///test this
        => Songs.Sum(s => s.Price);

    [Required]
    [ForeignKey(nameof(Producer))]
    public int? ProducerId { get; set; }
    public virtual Producer? Producer { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = null!;
}
