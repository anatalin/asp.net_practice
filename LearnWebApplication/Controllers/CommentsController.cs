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

        // PUT: api/Comments/5
        public void PutComment(Comment comment)
        {
            cs.UpdateComment(comment);
        }

        // DELETE: api/Comments/5
        public void DeleteComment(int id)
        {
            cs.DeleteComment(id);
        }
    }
}
