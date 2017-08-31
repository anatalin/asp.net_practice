using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Core.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        public Comment Add(Comment entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var comment = context.Comments.Add(entity);
                context.SaveChanges();
                return comment;
            }
        }

        public void Delete(Comment entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.Comments.Remove(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int entityId)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                Comment toDelete = new Comment { CommentId = entityId};
                context.Comments.Attach(toDelete);
                context.Comments.Remove(toDelete);
                context.SaveChanges();
            }
        }

        public Comment Get(int id)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                return context.Comments.Where(c => c.CommentId == id).SingleOrDefault();
            }
        }

        public IEnumerable<Comment> GetByPost(int postId)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                return context.Comments.Where(c => c.PostId == postId).ToList();
            }
        }

        public IEnumerable<Comment> GetAll()
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                return context.Comments.ToList();
            }
        }

        public Comment Update(Comment entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var updatedComment = context.Comments.SingleOrDefault(c => c.CommentId == entity.CommentId);

                if (updatedComment == null)
                {
                    return null;                   
                }

                context.Entry(updatedComment).CurrentValues.SetValues(entity);
                context.SaveChanges();

                return updatedComment;
            }
        }

        public IEnumerable<Comment> GetByExpression(Expression<Func<Comment, bool>> predicate)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                return context.Comments.Where(predicate).ToList();
            }
        }
    }
}
