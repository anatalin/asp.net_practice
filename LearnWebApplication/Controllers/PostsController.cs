﻿using LearnWebApplication.Filters;
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
    /// Контроллер предоставляет интерфейс взаимодействия с постами
    /// </summary>
    [ModelException]
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

        /// <summary>
        /// Возвращает все посты из БД
        /// </summary>
        /// <remarks>
        /// Возвращает список всех сущностей хранящиеся в БД
        /// </remarks>
        /// <returns></returns>
        // GET: api/Posts
        [Route("api/posts")]
        public Result<IEnumerable<PostGetProxy>> GetAll()
        {
            return new Result<IEnumerable<PostGetProxy>>() { Data = ps.GetAllPosts()};
        }

        /// <summary>
        /// Возвращает пост по его идентификатору
        /// </summary>
        /// <remarks>
        /// Возвращает сущность поста
        /// </remarks>
        /// <param name="id">Идентификатор поста</param>
        /// <returns>Сущность поста из БД</returns>
        // GET: api/Posts/5
        [Route("api/posts/{id}")]
        public Result<PostGetProxy> Get(int id)
        {
            return new Result<PostGetProxy>() { Data = ps.GetPost(id) };
        }

        /// <summary>
        /// Создает пост переданный в теле запроса
        /// </summary>
        /// <param name="post"></param>
        // POST: api/Posts
        //Add Post entity
        [HttpPost]
        [Route("api/posts")]
        public Result<PostGetProxy> Create(PostGetProxy post)
        {
            return new Result<PostGetProxy>() { Data = ps.Add(post) };
        }

        /// <summary>
        /// Обновляет информацию о посте
        /// </summary>
        /// <param name="post"></param>
        // PUT: api/Posts
        //Редактирование поста
        [HttpPut]
        [Route("api/posts")]
        public Result<PostGetProxy> Update(PostGetProxy post)
        {
            return new Result<PostGetProxy>() { Data = ps.UpdatePost(post) };
        }

        /// <summary>
        /// Удаляет пост
        /// </summary>
        /// <param name="id"></param>
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
