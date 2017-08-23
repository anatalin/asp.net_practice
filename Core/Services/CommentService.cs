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
        public IEnumerable<Comment> GetComments(int postId)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var commentRepo = new CommentRepository(context);

                return commentRepo.GetByPost(postId).ToList();
            }
        }

        public bool AddCommentByPost(int postId, Comment comment)
        {
            try
            {
                using (LearnDBContext context = new LearnDBContext())
                {
                    var commentRepo = new CommentRepository(context);

                    commentRepo.Add(postId, comment);

                    context.SaveChanges();
                }
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
                using (LearnDBContext context = new LearnDBContext())
                {
                    var commentRepo = new CommentRepository(context);

                    commentRepo.Update(comment);

                    context.SaveChanges();
                }
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
                using (LearnDBContext context = new LearnDBContext())
                {
                    var commentRepo = new CommentRepository(context);

                    commentRepo.Delete(id);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //private void SuperTest()
        //{
        //    LearnDBContext context = new LearnDBContext();
        //    context.Students.Select(s => new {Student = s, JournalCount = s.Journals.GroupBy(j => j.Mark).Select(j => new { Mark = j.Mark, Cnt = j.Count()}) });

        //    if (context.Posts.Any())
        //    {

        //    }
        //}
    }
}
