using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
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
            return postRepo.GetAll();
        }

        public Post GetPost(int id)
        {
            return postRepo.Get(id);
        }

        public bool TryAdd(Post post)
        {
            try
            {
                postRepo.Add(post);              
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
                postRepo.Update(post);
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
                postRepo.Delete(postId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
