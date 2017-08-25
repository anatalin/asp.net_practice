using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class LearnDBInitializer: CreateDatabaseIfNotExists<LearnDBContext>
    {
        protected override void Seed(LearnDBContext context)
        {
            for (int k = 0; k < 10; k++)
            {
                //List<Post> posts = new List<Post>();                

                context.Authors.AddOrUpdate(a => a.AuthorId, new Author
                {
                    FirstName = String.Format("FirstName {0}", k),
                    LastName = String.Format("LastName {0}", k),
                    BirthDate = DateTime.Now,
                    Address = String.Format("Address {0}", k)
                });
            }
            context.SaveChanges();

            foreach (var author in context.Authors)
            {
                for (int i = 0; i < 10; i++)
                {
                    List<Comment> comments = new List<Comment>();
                    for (int j = 0; j < 5; j++)
                    {
                        comments.Add(new Comment { Text = String.Format("Comment {0}", j), PublishDate = DateTime.Now, AuthorId = author.AuthorId });
                    }

                    context.Posts.AddOrUpdate(p => p.PostId, new Post { Text = String.Format("Post text {0}", i), Description = String.Format("Description {0}", i), PublishDate = DateTime.Now, AuthorId = author.AuthorId, Comments = comments}); 
                }                
            }
            context.SaveChanges();            

            base.Seed(context);
        }
    }
}
