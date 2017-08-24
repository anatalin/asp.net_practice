using Core;
using Core.Models;
using Core.Repositories;
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

        public PostService()
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

        public Post GetPost(int id)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var postRepo = new PostRepository(context);

                return postRepo.Get(id);
            }
        }

        public bool TryAdd(Post post)
        {
            try
            {
                using (LearnDBContext context = new LearnDBContext())
                {
                    var postRepo = new PostRepository(context);

                    postRepo.Add(post);

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
