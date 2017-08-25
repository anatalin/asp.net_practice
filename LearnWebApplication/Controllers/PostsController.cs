using Services.ProxyModels;
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
    /// Контроллер предоставляет интерфейс взаимодействия с постами
    /// </summary>
    public class PostsController : ApiController
    {
        private readonly IPostService ps;
        private readonly ICommentService cs;

        /// <summary>
        /// Контроллер предоставляет интерфейс для работы с постами
        /// </summary>
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

        /// <summary>
        /// Получает пост по его идентификатору
        /// </summary>
        /// <remarks>
        /// Получает сущность поста
        /// </remarks>
        /// <param name="id">Идентификатор поста</param>
        /// <returns>Сущность поста из БД</returns>
        // GET: api/Posts/5
        [Route("api/posts/{id}")]
        public PostGetProxy Get(int id)
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
