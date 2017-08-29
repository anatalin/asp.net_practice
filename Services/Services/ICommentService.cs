using Services.ProxyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentGetProxy> GetComments(int postId);
        bool AddCommentByPost(int postId, CommentGetProxy comment);
        void UpdateComment(CommentGetProxy comment);
        void DeleteComment(int id);
    }
}
