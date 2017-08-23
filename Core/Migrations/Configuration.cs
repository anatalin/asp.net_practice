using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Core.LearnDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Core.LearnDBContext";
        }

        protected override void Seed(Core.LearnDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            //for (int i = 0; i < 100; i++)
            //{
            //    List<Comment> comments = new List<Comment>();

            //    for (int j = 0; j < 5; j++)
            //    {
            //        comments.Add(new Comment { CommentText = String.Format("Comment {0}", j) });
            //    }

            //    context.Posts.AddOrUpdate(p => p.PostId, new Post { PublishDate = DateTime.Now, Comments = comments});
            //}
        }
    }
}
