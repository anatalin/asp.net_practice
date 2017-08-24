using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CommentService: ICommentService
    {
        private readonly IRepository<Comment> commentRepo;

        public CommentService(IRepository<Comment> commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        public IEnumerable<Comment> GetComments(int postId)
        {
            //return commentRepo.GetByPost(postId).ToList();
            return commentRepo.GetByExpression(c => c.PostId == postId).ToList();
        }

        public bool AddCommentByPost(int postId, Comment comment)
        {
            try
            {
                comment.PostId = postId;
                commentRepo.Add(comment);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateComment(Comment comment)
        {
            try
            {
                commentRepo.Update(comment);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteComment(int id)
        {
            try
            {
                commentRepo.Delete(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
