﻿using Core;
using Core.Models;
using Core.Repositories;
using Services.ProxyModels;
using Services.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PostService: IPostService
    {
        private readonly IRepository<Post> postRepo;

        public PostService(IRepository<Post> postRepo)
        {
            this.postRepo = postRepo;
        }

        public IEnumerable<PostGetProxy> GetAllPosts()
        {
            return ((List<Post>)postRepo.GetAll()).ConvertAll<PostGetProxy>(Converters.Converter<Post,PostGetProxy>.Convert);  
        }

        public PostGetProxy GetPost(int id)
        {
            Post dbPost;

            dbPost = postRepo.Get(id);
            
            if (dbPost != null)
            {
                return Converters.Converter<Post, PostGetProxy>.Convert(dbPost);
            }
            else
                throw new Exception("Not found entity in DB.");
        }

        public bool TryAdd(PostGetProxy postProxy)
        {
            try
            {
                Post dbPost;

                if (postProxy == null)
                {
                    return false;                    
                }

                dbPost = Converters.Converter<PostGetProxy, Post>.Convert(postProxy);

                postRepo.Add(dbPost);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdatePost(PostGetProxy postProxy)
        {
            try
            {
                Post dbPost;

                if (postProxy == null)
                {
                    return;
                }

                dbPost = Converters.Converter<PostGetProxy, Post>.Convert(postProxy);
                postRepo.Update(dbPost);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeletePost(int postId)
        {
            try
            {
                postRepo.Delete(postId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}