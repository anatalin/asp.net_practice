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
    public class PostsController : ApiController
    {
        private readonly IPostService ps;
        private readonly ICommentService cs;

        public PostsController(IPostService postService, ICommentService commentService)
        {
            this.ps = postService;
            this.cs = commentService;
        }

        // GET: api/Posts
        public IEnumerable<Post> GetPosts()
        {
            //PostService ps = new PostService();

            return ps.GetAllPosts();
        }

        // GET: api/Posts/5
        public Post Get(int id)
        {
            //PostService ps = new PostService();

            return ps.GetPost(id);
        }

        // POST: api/Posts
        //Add Post entity
        public void PostPost(Post post)
        {
            //PostService ps = new PostService();

            if(!ps.TryAdd(post))
            {
                //что если ошибка?
            }
        }

        // PUT: api/Posts
        //Редактирование поста
        public void PutPost(Post post)
        {
            ps.UpdatePost(post);
        }

        // DELETE: api/Posts/{id}
        //удаление поста
        public void DeletePost(int id)
        {
            ps.DeletePost(id);
        }

        [Route("api/posts/{postId}/comments")]
        public IEnumerable<Comment> GetComment(int postId)
        {
            //CommentService cs = new CommentService();
            IEnumerable<Comment> list = cs.GetComments(postId);
            return cs.GetComments(postId);
        }

        //Добавление комментария к посту
        [Route("api/posts/{postId}/comments")]
        public void PostComment(int postId, Comment comment)
        {
            //CommentService cs = new CommentService();
            if (!cs.AddCommentByPost(postId, comment))
            {
                //обработать ошибку
            }
        }
    }
}
