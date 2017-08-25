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

namespace Services.Services
{
    public class PostService: IPostService
    {
        private readonly IRepository<Post> postRepo;

        public PostService(IRepository<Post> postRepo)
        {
            this.postRepo = postRepo;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var postRepo = new PostRepository(context);

                return postRepo.GetAll().ToList();
            }
        }

        public PostGetProxy GetPost(int id)
        {
            Post dbPost;

            using (LearnDBContext context = new LearnDBContext())
            {
                var postRepo = new PostRepository(context);

                dbPost = postRepo.Get(id);
            }

            if (dbPost != null)
            {
                return Converters.Converter<Post, PostGetProxy>.ToProxy(dbPost);
            }
            else
                throw new Exception("Not found entity in DB.");
        }

        public bool TryAdd(PostGetProxy postProxy)
        {
            try
            {
                Post dbPost;

                if (postProxy == null)
                {
                    return false;                    
                }

                dbPost = Converters.Converter<PostGetProxy, Post>.ToProxy(postProxy);

                using (LearnDBContext context = new LearnDBContext())
                {
                    var postRepo = new PostRepository(context);

                    postRepo.Add(dbPost);

                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdatePost(Post post)
        {
            try
            {
                using (LearnDBContext context = new LearnDBContext())
                {
                    var postRepo = new PostRepository(context);

                    postRepo.Update(post);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeletePost(int postId)
        {
            try
            {
                using (LearnDBContext context = new LearnDBContext())
                {
                    var postRepo = new PostRepository(context);

                    postRepo.Delete(postId);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
