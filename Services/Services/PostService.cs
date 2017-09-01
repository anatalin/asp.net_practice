using Core;
using Core.Models;
using Core.Repositories;
using Services.ProxyModels;
using Services.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Results;
using Core.Exceptions;
using Services.Exceptions;

namespace Services.Services
{
    public class PostService: IPostService
    {
        private readonly IRepository<Post> postRepo;

        public PostService(IRepository<Post> postRepo)
        {
            this.postRepo = postRepo;
        }

        public IEnumerable<PostGetProxy> GetAllPosts()
        {
            return ((List<Post>)postRepo.GetAll()).ConvertAll<PostGetProxy>(Converters.Converter<Post,PostGetProxy>.Convert);  
        }

        public Result<PostGetProxy> GetPost(int id)
        {
            Post dbPost;
            PostGetProxy pgp;

            dbPost = postRepo.Get(id);

            pgp = Converters.Converter<Post, PostGetProxy>.Convert(dbPost);

            return new Result<PostGetProxy>() { Data = pgp};

        }

        public bool Add(PostGetProxy postProxy)
        {
            Post dbPost;

            if (postProxy == null)
            {
                return false;                    
            }

            dbPost = Converters.Converter<PostGetProxy, Post>.Convert(postProxy);

            postRepo.Add(dbPost);
            return true;
        }

        public void UpdatePost(PostGetProxy postProxy)
        {
            Post dbPost;

            if (postProxy == null)
            {
                return;
            }

            dbPost = Converters.Converter<PostGetProxy, Post>.Convert(postProxy);
            postRepo.Update(dbPost);
        }

        public void DeletePost(int postId)
        {
            postRepo.Delete(postId);
        }
    }
}
