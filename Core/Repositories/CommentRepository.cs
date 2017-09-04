using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Core.Exceptions;

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
                var toDeleteComment = context.Comments.FirstOrDefault(c => c.CommentId == entity.CommentId);

                if (toDeleteComment == null)
                    throw new NotFoundException($"Комментарий с id = {entity.CommentId} не найден.");

                context.Comments.Remove(toDeleteComment);
                context.SaveChanges();
            }
        }

        public void Delete(int entityId)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var toDeleteComment = context.Comments.FirstOrDefault(c => c.CommentId == entityId);

                if (toDeleteComment == null)
                    throw new NotFoundException($"Комментарий с id = {entityId} не найден.");

                context.Comments.Remove(toDeleteComment);
                context.SaveChanges();
            }
        }

        public Comment Get(int id)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;

                var result = context.Comments.Where(c => c.CommentId == id).SingleOrDefault();

                if (result == null)
                    throw new NotFoundException($"Комментарий с id = {id} не найден.");

                return result;
            }
        }

        public IEnumerable<Comment> GetByPost(int postId)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                var commentList = context.Comments.Where(c => c.PostId == postId).ToList();

                if (commentList.Count() == 0)
                    throw new NotFoundException("Не был найден ни один комментарий.");

                return commentList;
            }
        }

        public IEnumerable<Comment> GetAll()
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                var commentList = context.Comments.ToList();

                if(commentList.Count() == 0)
                    throw new NotFoundException("Не был найден ни один комментарий.");

                return commentList;
            }
        }

        public Comment Update(Comment entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var updatedComment = context.Comments.SingleOrDefault(c => c.CommentId == entity.CommentId);

                if (updatedComment == null)
                    throw new NotFoundException($"Комментарий с id = {entity.PostId} не найден.");

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
                var commentList = context.Comments.Where(predicate).ToList();

                if(commentList.Count() == 0)
                    throw new NotFoundException("Не был найден ни один комментарий.");

                return commentList;
            }
        }
    }
}
