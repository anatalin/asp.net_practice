using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class PostRepository: IRepository<Post>
    {
        private LearnDBContext context;

        public PostRepository(LearnDBContext context)
        {
            this.context = context;
        }

        public Post Add(Post entity)
        {
            return context.Posts.Add(entity);
        }

        public void Delete(Post entity)
        {
            context.Posts.Remove(entity);
        }

        public void Delete(int entityId)
        {
            this.Delete(context.Posts.SingleOrDefault(p => p.PostId == entityId));
        }

        public Post Get(int id)
        {
            return context.Posts.Where(p => p.PostId == id).SingleOrDefault();
        }

        public IQueryable<Post> GetAll()
        {
            return context.Posts;
        }

        public Post Update(Post entity)
        {
            var updatedPost = context.Posts.SingleOrDefault(p => p.PostId == entity.PostId);

            if (updatedPost != null)
            {
                //перебрать все поля, что очень не хорошо.
                updatedPost.PublishDate = entity.PublishDate;
            }

            return updatedPost;
        }
    }
}
