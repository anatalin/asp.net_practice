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
            Post post;
            using (LearnDBContext context = new LearnDBContext())
            {
                post = context.Posts.First();
            }

            PostGetProxy postProxy = Services.Converters.Converter<Post, PostGetProxy>.Convert(post);

            Assert.AreEqual(post.AuthorId, postProxy.AuthorId);
            Assert.AreEqual(post.Description, postProxy.Description);
            Assert.AreEqual(post.PostId, postProxy.PostId);
            Assert.AreEqual(post.PublishDate, postProxy.PublishDate);
            Assert.AreEqual(post.Text, postProxy.Text);
        }
    }
}
