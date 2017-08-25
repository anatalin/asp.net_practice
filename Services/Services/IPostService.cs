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
        IEnumerable<PostGetProxy> GetAllPosts();
        PostGetProxy GetPost(int id);
        bool TryAdd(PostGetProxy post);
        void UpdatePost(PostGetProxy post);
        void DeletePost(int postId);
    }
}
