using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetComments(int postId);
        bool AddCommentByPost(int postId, Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int id);
    }
}
