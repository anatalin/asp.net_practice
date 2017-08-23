using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private LearnDBContext context;

        public CommentRepository(LearnDBContext context)
        {
            this.context = context;
        }

        public Comment Add(Comment entity)
        {
            return context.Comments.Add(entity);
        }

        public Comment Add(int postId, Comment comment)
        {
            comment.PostId = postId;
            return this.Add(comment);
        }

        public void Delete(Comment entity)
        {
            context.Comments.Remove(entity);
        }

        public void Delete(int entityId)
        {
            this.Delete(context.Comments.SingleOrDefault(c => c.CommentId == entityId));
        }

        public Comment Get(int id)
        {
            return context.Comments.Where(c => c.CommentId == id).SingleOrDefault();
        }

        public IQueryable<Comment> GetByPost(int postId)
        {
            return context.Comments.Where(c => c.PostId == postId);
        }

        public IQueryable<Comment> GetAll()
        {
            return context.Comments;
        }

        public Comment Update(Comment entity)
        {
            var updatedComment = context.Comments.SingleOrDefault(c => c.CommentId == entity.CommentId);

            if (updatedComment != null)
            {
                //перебрать все поля, что очень не хорошо.
                updatedComment.CommentText = entity.CommentText;
            }

            return updatedComment;
        }
    }
}
