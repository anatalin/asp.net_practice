using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;
using Core.Exceptions;

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

                var toDeletePost = context.Posts.FirstOrDefault(p => p.PostId == entity.PostId);

                if (toDeletePost == null)
                    throw new NotFoundException(String.Format("Пост с id = {0} не найден.", entity.PostId));

                context.Posts.Remove(toDeletePost);
                context.SaveChanges();
            }
        }

        public void Delete(int entityId)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                //Т.к. отключено каскадное удаление приходится помнить что сначало нужно удалить все связные комментарии, что я считаю плохо

                context.Comments.Where(c => c.PostId == entityId).Delete();
                
                var toDeletePost = context.Posts.FirstOrDefault(p => p.PostId == entityId);

                if (toDeletePost == null)
                    throw new NotFoundException(String.Format("Пост с id = {0} не найден.", entityId));

                context.Posts.Remove(toDeletePost);
                context.SaveChanges();
            }
        }

        public Post Get(int id)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;

                var result = context.Posts.Include(p => p.Author).Where(p => p.PostId == id).SingleOrDefault();

                if (result == null)
                    throw new NotFoundException(String.Format("Пост с id = {0} не найден.", id));

                return result;
            }
        }

        public IEnumerable<Post> GetAll()
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                var postList = context.Posts.ToList();

                if (postList.Count() == 0)
                    throw new NotFoundException("Не был найден ни один пост.");

                return postList;
            }
        }

        public IEnumerable<Post> GetByExpression(Expression<Func<Post, bool>> predicate)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                var postList = context.Posts.Where(predicate).ToList();

                if (postList.Count() == 0)
                    throw new NotFoundException("Не был найден ни один пост по заданному критерию.");

                return postList;
            }
        }

        public Post Update(Post entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var updatedPost = context.Posts.SingleOrDefault(p => p.PostId == entity.PostId);

                if (updatedPost == null)
                    throw new NotFoundException(String.Format("Пост с id = {0} не найден.", entity.PostId));

                context.Entry(updatedPost).CurrentValues.SetValues(entity);
                context.SaveChanges();

                return updatedPost;
            }
        }
    }
}
