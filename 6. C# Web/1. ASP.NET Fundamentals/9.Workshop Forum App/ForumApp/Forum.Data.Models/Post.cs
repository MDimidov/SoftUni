using System.ComponentModel.DataAnnotations;
using static Forum.Common.Validations.ValidationsConstants.Post;

namespace Forum.Data.Models;

public class Post
{
	public Post()
	{
		Id = Guid.NewGuid();
	}

	[Key]
	public Guid Id { get; set; }

	[Required]
	[MaxLength(TitleMaxLength)]
	public string Title { get; set; } = null!;

	[Required]
	[MaxLength(ContentMaxLength)]
	public string Content { get; set; } = null!;
}
