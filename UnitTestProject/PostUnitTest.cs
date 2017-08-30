using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Models;
using Core;
using System.Linq;
using Services.ProxyModels;

namespace UnitTestProject
{
    [TestClass]
    public class PostUnitTest
    {
        [TestMethod]
        public void CompareDbEntityWithProxy()
        {
            Post post = new Post {
                Author = new Author { AuthorId = 1, Address = "Mordovia", BirthDate = DateTime.Now, FirstName="firstname", LastName = "lastname"},
                AuthorId = 1,
                Description = "Qwerty",
                PostId = 23,
                PublishDate = DateTime.Now,
                Text = "fdsdsfkdg;kf;gkd;fgl'df;gkd;fgk'dgk'df;gk'dgkd;b,kv.cb,m"
            };
            
            PostGetProxy postProxy = Services.Converters.Converter<Post, PostGetProxy>.Convert(post);

            Assert.AreEqual(post.AuthorId, postProxy.AuthorId);
            Assert.AreEqual(post.Description, postProxy.Description);
            Assert.AreEqual(post.PostId, postProxy.PostId);
            Assert.AreEqual(post.PublishDate, postProxy.PublishDate);
            Assert.AreEqual(post.Text, postProxy.Text);
        }
    }
}
