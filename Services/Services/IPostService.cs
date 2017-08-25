using Core.Models;
using Services.ProxyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();
        PostGetProxy GetPost(int id);
        bool TryAdd(PostGetProxy post);
        void UpdatePost(Post post);
        void DeletePost(int postId);
    }
}
