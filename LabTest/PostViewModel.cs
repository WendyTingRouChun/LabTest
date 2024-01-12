using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTest
{
    public class PostViewModel : ObservableObject
    {
        private ObservableCollection<PostRecord> _posts;
        public ObservableCollection<PostRecord> Posts
        {
            get => _posts;
            set => SetProperty(ref _posts, value);
        }
        public string NewPostTitle { get; internal set; }
        public string NewPostBody { get; internal set; }

        private readonly ApiService _apiService;

        public PostViewModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task GetPosts()
        {
            Posts = new ObservableCollection<PostRecord>(await _apiService.GetPosts());
        }

        public async Task<PostRecord> GetPostById(int postId)
        {
            return await _apiService.GetPostById(postId);
        }

        public async Task AddOrUpdatePost(PostRecord post)
        {
            if (post.Id == 0)
            {
                // Add a new post
                await _apiService.AddPost(post);
            }
            else
            {
                // Update an existing post
                await _apiService.UpdatePost(post);
            }

            // Refresh the posts after add or update
            await GetPosts();
        }

        public async Task DeletePost(int postId)
        {
            // Delete the post if confirmed
            await _apiService.DeletePost(postId);

            // Refresh the posts after delete
            await GetPosts();
        }
    }


}
