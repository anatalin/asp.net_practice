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
            try
            {
                using (LearnDBContext context = new LearnDBContext())
                {
                    var post = context.Posts.Add(entity);
                    context.SaveChanges();
                    return post;
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(String.Format("Ошибка вставки поста. Post: {0}", entity.ToString()), ex);
            }
        }

        public void Delete(Post entity)
        {
            try
            {
                using (LearnDBContext context = new LearnDBContext())
                {
                    context.Comments.Where(c => c.PostId == entity.PostId).Delete();
                    context.Posts.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(String.Format("Ошибка удаления поста. Post: {0}", entity.ToString()), ex);
            }
        }

        public void Delete(int entityId)
        {
            try
            {
                using (LearnDBContext context = new LearnDBContext())
                {
                    //Т.к. отключено каскадное удаление приходится помнить что сначало нужно удалить все связные комментарии, что я считаю плохо

                    context.Comments.Where(c => c.PostId == entityId).Delete();

                    Post toDelete = new Post { PostId = entityId };
                    context.Posts.Attach(toDelete);
                    context.Posts.Remove(toDelete);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(String.Format("Ошибка удаления поста. PostId: {0}", entityId), ex);
            }
        }

        public Post Get(int id)
        {
            try
            {
                using (LearnDBContext context = new LearnDBContext())
                {
                    context.UseRecompileOption = true;
                    return context.Posts.Include(p => p.Author).Where(p => p.PostId == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(String.Format("Ошибка чтения поста. PostId: {0}", id), ex);
            }
        }

        public IEnumerable<Post> GetAll()
        {
            try
            {
                using (LearnDBContext context = new LearnDBContext())
                {
                    context.UseRecompileOption = true;
                    return context.Posts.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException("Ошибка чтения постов", ex);
            }
        }

        public IEnumerable<Post> GetByExpression(Expression<Func<Post, bool>> predicate)
        {
            try
            {
                using (LearnDBContext context = new LearnDBContext())
                {
                    context.UseRecompileOption = true;
                    return context.Posts.Where(predicate).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException("Ошибка чтения постов", ex);
            }
        }

        public Post Update(Post entity)
        {
            try
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
            catch (Exception ex)
            {
                throw new DataAccessLayerException(String.Format("Ошибка обновления поста. Post: {0}", entity.ToString()), ex);
            }
        }
    }
}
