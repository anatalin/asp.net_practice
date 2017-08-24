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
        [Route("api/posts")]
        public IEnumerable<Post> GetAll()
        {
            //PostService ps = new PostService();

            return ps.GetAllPosts();
        }

        // GET: api/Posts/5
        [Route("api/posts/{id}")]
        public Post Get(int id)
        {
            //PostService ps = new PostService();

            return ps.GetPost(id);
        }

        // POST: api/Posts
        //Add Post entity
        [HttpPost]
        [Route("api/posts")]
        public void Create(Post post)
        {
            //PostService ps = new PostService();

            if(!ps.TryAdd(post))
            {
                //что если ошибка?
            }
        }

        // PUT: api/Posts
        //Редактирование поста
        [HttpPut]
        [Route("api/posts")]
        public void Update(Post post)
        {
            ps.UpdatePost(post);
        }

        // DELETE: api/Posts/{id}
        //удаление поста
        [HttpDelete]
        [Route("api/posts/{id}")]
        public void Delete(int id)
        {
            ps.DeletePost(id);
        }        
    }
}
