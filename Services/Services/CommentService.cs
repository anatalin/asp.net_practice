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

        public CommentGetProxy AddCommentByPost(int postId, CommentGetProxy commentProxy)
        {
            Comment commentDb;

            if (commentProxy == null)
                throw new ArgumentNullException("commentProxy");

            commentDb = Converters.Converter<CommentGetProxy, Comment>.Convert(commentProxy);

            commentDb.PostId = postId;            

            return Converters.Converter<Comment, CommentGetProxy>.Convert(commentRepo.Add(commentDb));            
        }

        public CommentGetProxy UpdateComment(CommentGetProxy commentProxy)
        {
            Comment commentDb;

            if (commentProxy == null)
                throw new ArgumentNullException("commentProxy");

            commentDb = Converters.Converter<CommentGetProxy, Comment>.Convert(commentProxy);

            return Converters.Converter<Comment, CommentGetProxy>.Convert(commentRepo.Update(commentDb));
        }

        public void DeleteComment(int id)
        {
            commentRepo.Delete(id);            
        }
    }
}
