using Core.Models;
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
        Post GetPost(int id);
        bool TryAdd(Post post);
        void UpdatePost(Post post);
        void DeletePost(int postId);
    }
}
