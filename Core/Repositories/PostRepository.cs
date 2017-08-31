using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;

namespace Core.Repositories
{
    public class PostRepository: IRepository<Post>
    {
        public Post Add(Post entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var post = context.Posts.Add(entity);
                context.SaveChanges();
                return post;
            }
        }

        public void Delete(Post entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.Comments.Where(c => c.PostId == entity.PostId).Delete();
                context.Posts.Remove(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int entityId)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                //Т.к. отключено каскадное удаление приходится помнить что сначало нужно удалить все связные комментарии, что я считаю плохо
                try
                {
                    //Метод расширения Delete() из библиотеки Z.EntityFramework.Plus предположительно должен удалять одним запросом несколько записей,
                    //но не работает из-за option(recompile)
                    context.Comments.Where(c => c.PostId == entityId).Delete();
                    //context.Comments.RemoveRange(context.Comments.Where(c => c.PostId == entityId));
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                Post toDelete = new Post { PostId = entityId };
                context.Posts.Attach(toDelete);
                context.Posts.Remove(toDelete);

                context.SaveChanges();
                }
        }

        public Post Get(int id)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                return context.Posts.Include(p => p.Author).Where(p => p.PostId == id).SingleOrDefault();
            }
        }

        public IEnumerable<Post> GetAll()
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                return context.Posts.ToList();
            }
        }

        public IEnumerable<Post> GetByExpression(Expression<Func<Post, bool>> predicate)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                return context.Posts.Where(predicate).ToList();
            }
        }

        public Post Update(Post entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var updatedPost = context.Posts.SingleOrDefault(p => p.PostId == entity.PostId);

                if (updatedPost == null)
                {
                    return null;
                }

                context.Entry(updatedPost).CurrentValues.SetValues(entity);
                context.SaveChanges();

                return updatedPost;
            }
        }
    }
}
