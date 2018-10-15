using Core.Models;
using LearnWebApplication.Filters;
using Services.ProxyModels;
using Services.Results;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnWebApplication.Controllers
{
    /// <summary>
    /// Предоставляет интерфейс взаимодействия с комментариями
    /// </summary>
    [ModelException]
    public class CommentsController : ApiController
    {
        private readonly ICommentService cs;

        public CommentsController(ICommentService commentService)
        {
            cs = commentService;
        }

        /// <summary>
        /// Обновляет данные комментария
        /// </summary>
        /// <param name="comment"></param>
        // PUT: api/Comments
        [HttpPut]
        [Route("api/comments")]
        public Result<CommentGetProxy> Update(CommentGetProxy comment)
        {
            return new Result<CommentGetProxy>() { Data = cs.UpdateComment(comment) };
        }

        /// <summary>
        /// Удаляет комментарий
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/Comments/5
        [HttpDelete]
        [Route("api/comments/{id}")]
        public void Delete(int id)
        {
            cs.DeleteComment(id);
        }

        /// <summary>
        /// Получает все комментарии заданного поста
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/posts/{postId}/comments")]
        public Result<IEnumerable<CommentGetProxy>> Get(int postId)
        {
            return new Result<IEnumerable<CommentGetProxy>>() { Data = cs.GetComments(postId) };
        }

        /// <summary>
        /// Добавляет комментарии к заданному посту
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="comment"></param>
        [HttpPost]
        [Route("api/posts/{postId}/comments")]
        public Result<CommentGetProxy> Create(int postId, CommentGetProxy comment)
        {
            return new Result<CommentGetProxy>() { Data = cs.AddCommentByPost(postId, comment)};
        }
    }
}
