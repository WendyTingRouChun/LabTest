using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LabTest
{
    public class ApiService
    {
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/posts";

        public async Task<List<PostRecord>> GetPosts()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetFromJsonAsync<List<PostRecord>>(BaseUrl);
                return response ?? new List<PostRecord>();
            }
        }

        public async Task<PostRecord> GetPostById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetFromJsonAsync<PostRecord>($"{BaseUrl}/{id}");
                return response;
            }
        }

        public async Task AddPost(PostRecord post)
        {
            using (HttpClient client = new HttpClient())
            {
                await client.PostAsJsonAsync(BaseUrl, post);
            }
        }

        public async Task UpdatePost(PostRecord post)
        {
            using (HttpClient client = new HttpClient())
            {
                await client.PutAsJsonAsync($"{BaseUrl}/{post.Id}", post);
            }
        }

        public async Task DeletePost(int postId)
        {
            using (HttpClient client = new HttpClient())
            {
                await client.DeleteAsync($"{BaseUrl}/{postId}");
            }
        }
    }
}
