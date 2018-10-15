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

        public PostGetProxy GetPost(int id)
        {
            Post dbPost;
            PostGetProxy pgp;

            dbPost = postRepo.Get(id);

            pgp = Converters.Converter<Post, PostGetProxy>.Convert(dbPost);

            return pgp;

        }

        public PostGetProxy Add(PostGetProxy postProxy)
        {
            Post dbPost;

            if (postProxy == null)
                throw new ArgumentNullException("postProxy");

            dbPost = Converters.Converter<PostGetProxy, Post>.Convert(postProxy);
            
            return Converters.Converter<Post, PostGetProxy>.Convert(postRepo.Add(dbPost));
        }

        public PostGetProxy UpdatePost(PostGetProxy postProxy)
        {
            Post dbPost;

            if (postProxy == null)
                throw new ArgumentNullException("postProxy");

            dbPost = Converters.Converter<PostGetProxy, Post>.Convert(postProxy);
            return Converters.Converter<Post, PostGetProxy>.Convert(postRepo.Update(dbPost));
        }

        public void DeletePost(int postId)
        {
            postRepo.Delete(postId);
        }
    }
}
