using Core;
using Core.Models;
using Core.Repositories;
using Services.ProxyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CommentService: ICommentService
    {
        private readonly IRepository<Comment> commentRepo;

        public CommentService(IRepository<Comment> commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        public IEnumerable<CommentGetProxy> GetComments(int postId)
        {
            return ((List<Comment>)commentRepo.GetByExpression(c => c.PostId == postId)).ConvertAll<CommentGetProxy>(Converters.Converter<Comment,CommentGetProxy>.Convert);
        }

        public bool AddCommentByPost(int postId, CommentGetProxy commentProxy)
        {
            try
            {
                Comment commentDb;

                if (commentProxy == null)
                {
                    return false;
                }

                commentDb = Converters.Converter<CommentGetProxy, Comment>.Convert(commentProxy);

                commentDb.PostId = postId;
                commentRepo.Add(commentDb);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateComment(CommentGetProxy commentProxy)
        {
            try
            {
                Comment commentDb;

                if (commentProxy == null)
                {
                    return;
                }

                commentDb = Converters.Converter<CommentGetProxy, Comment>.Convert(commentProxy);

                commentRepo.Update(commentDb);
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
