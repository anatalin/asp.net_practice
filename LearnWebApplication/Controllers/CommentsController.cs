using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnWebApplication.Controllers
{
    public class CommentsController : ApiController
    {
        private readonly ICommentService cs;

        public CommentsController(ICommentService commentService)
        {
            cs = commentService;
        }

        // PUT: api/Comments
        [HttpPut]
        [Route("api/comments")]
        public void Update(Comment comment)
        {
            cs.UpdateComment(comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete]
        [Route("api/comments/{id}")]
        public void Delete(int id)
        {
            cs.DeleteComment(id);
        }

        [HttpGet]
        [Route("api/posts/{postId}/comments")]
        public IEnumerable<Comment> Get(int postId)
        {
            //CommentService cs = new CommentService();
            IEnumerable<Comment> list = cs.GetComments(postId);
            return cs.GetComments(postId);
        }

        //Добавление комментария к посту
        [HttpPost]
        [Route("api/posts/{postId}/comments")]
        public void Create(int postId, Comment comment)
        {
            //CommentService cs = new CommentService();
            if (!cs.AddCommentByPost(postId, comment))
            {
                //обработать ошибку
            }
        }
    }
}
