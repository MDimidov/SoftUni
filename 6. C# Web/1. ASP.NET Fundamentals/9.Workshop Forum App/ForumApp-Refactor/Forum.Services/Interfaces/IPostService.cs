using Forum.ViewModels.Post;

namespace Forum.Services.Interfaces;

public interface IPostService
{
	Task<IEnumerable<PostViewModel>> ListAllAsync();	

	Task AddPostAsync(PostFormViewModel postViewModel);

	Task<PostFormViewModel> GetForEditOrDeleteByIdAsync(string id);

	Task EditPostAsync(string id, PostFormViewModel postViewModel);

	Task DeletePostAsync(string id);
}
