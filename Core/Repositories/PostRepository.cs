﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Core.Repositories
{
    public class PostRepository: IRepository<Post>
    {
        public PostRepository()
        {
            
        }

        public Post Add(Post entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var post = context.Posts.Add(entity);
                context.SaveChanges();
                return post;
            }
        }

        public void Delete(Post entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.Posts.Remove(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int entityId)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                //Т.к. отключено каскадное удаление приходится помнить что сначало нужно удалить все связные комментарии, что я считаю плохо
                foreach (var comment in context.Comments.Where(c => c.PostId == entityId))
                {
                    context.Comments.Remove(comment);
                }
                
                context.Posts.Remove(context.Posts.SingleOrDefault(p => p.PostId == entityId));

                context.SaveChanges();
            }
        }

        public Post Get(int id)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                return context.Posts.Include(p => p.Author).Where(p => p.PostId == id).SingleOrDefault();
            }
        }

        public IEnumerable<Post> GetAll()
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                return context.Posts.ToList();
            }
        }

        public IEnumerable<Post> GetByExpression(Expression<Func<Post, bool>> predicate)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                return context.Posts.Where(predicate).ToList();
            }
        }

        public Post Update(Post entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var updatedPost = context.Posts.SingleOrDefault(p => p.PostId == entity.PostId);

                if (updatedPost != null)
                {
                    //перебрать все поля, что очень не хорошо.
                    updatedPost.PublishDate = entity.PublishDate;
                    updatedPost.AuthorId = entity.AuthorId;
                    updatedPost.Description = entity.Description;
                    updatedPost.Text = entity.Text;
                }

                context.SaveChanges();

                return updatedPost;
            }
        }
    }
}
