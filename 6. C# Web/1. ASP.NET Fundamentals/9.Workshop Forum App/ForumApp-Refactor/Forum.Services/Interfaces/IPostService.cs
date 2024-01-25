using Forum.ViewModels.Post;

namespace Forum.Services.Interfaces;

public interface IPostService
{
	Task<IEnumerable<PostViewModel>> ListAllAsync();	

	Task AddPostAsync(PostFormViewModel postViewModel);

	Task EditPostAsync(PostFormViewModel postViewModel);
}
