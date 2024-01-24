using System.ComponentModel.DataAnnotations;
using static Forum.Common.Validations.ValidationsConstants.Posts;

namespace Forum.Data.Models;

public class Post
{
	public Post()
	{
		this.PostId = Guid.NewGuid();
	}

	[Key]
	public Guid PostId { get; set; }

	[Required]
	[MaxLength(TitleMaxLength)]
	public string Title { get; set; } = null!;

	[Required]
	[MaxLength(ContentMaxLength)]
	public string Content { get; set; } = null!;
}
