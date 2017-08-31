using Services.ProxyModels;
using Services.Results;
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
        Result<PostGetProxy> GetPost(int id);
        bool TryAdd(PostGetProxy post);
        void UpdatePost(PostGetProxy post);
        void DeletePost(int postId);
    }
}
