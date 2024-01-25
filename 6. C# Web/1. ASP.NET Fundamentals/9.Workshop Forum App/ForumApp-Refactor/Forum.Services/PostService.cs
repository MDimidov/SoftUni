using Forum.Data;
using Forum.Data.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.Post;
using Microsoft.EntityFrameworkCore;

namespace Forum.Services;

public class PostService : IPostService
{
	private readonly ForumDbContext dbContext;

	public PostService(ForumDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	public async Task AddPostAsync(PostFormViewModel postViewModel)
	{
		var post = new Post()
		{
			Title = postViewModel.Title,
			Content = postViewModel.Content,
		};

		await dbContext.Posts.AddAsync(post);
		await dbContext.SaveChangesAsync();
	}

	public async Task DeletePostAsync(string id)
	{
		var model = await dbContext
			.Posts
			.FirstOrDefaultAsync(p => p.PostId.ToString().Equals(id));

		if (model == null)
		{
			return;
		}
		else
		{
			dbContext.Posts.Remove(model);
			await dbContext.SaveChangesAsync();
		}
	}

	public async Task EditPostAsync(string id, PostFormViewModel postViewModel)
	{
		var post = await dbContext
			.Posts
			.FirstOrDefaultAsync(p => p.PostId.ToString().Equals(id));

		post!.Title = postViewModel.Title;
		post.Content = postViewModel.Content;

		await dbContext.SaveChangesAsync();
	}

	public async Task<PostFormViewModel> GetForEditOrDeleteByIdAsync(string id)
	{
		var post = await dbContext
			.Posts
			.FirstOrDefaultAsync(p => p.PostId.ToString() == id);

		PostFormViewModel postFormModel = new PostFormViewModel()
		{
			Content = post!.Content,
			Title = post.Title,
		};

		return postFormModel;
	}

	public async Task<IEnumerable<PostViewModel>> ListAllAsync()
	{
		IEnumerable<PostViewModel> allPost = await dbContext
			.Posts
			.Select(p => new PostViewModel
			{
				Id = p.PostId.ToString(),
				Title = p.Title,
				Content = p.Content,
			})
			.ToArrayAsync();

		return allPost;
	}
}
