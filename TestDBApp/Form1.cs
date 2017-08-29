using Core;
using Core.Models;
using Core.Repositories;
using Services.ProxyModels;
using Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDBApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                PostService ps = new PostService(new PostRepository());
                var prox = ps.GetPost(1);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                PostService ps = new PostService(new PostRepository());

                PostGetProxy postProxy = new PostGetProxy() {AuthorId=1, Description="Test description", PublishDate = DateTime.Now, Text="New text"};

                ps.TryAdd(postProxy);

                context.SaveChanges();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var commentRepo = new CommentRepository();

                commentRepo.Add(new Comment { Text = "This is comment for 1302 post", PostId = 1302});

                context.SaveChanges();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var postRepo = new PostRepository();

                postRepo.Delete(1);//(new Post { PostId = 1, PublishDate = Convert.ToDateTime("23.08.2017") });

                context.SaveChanges();
            }
        }
    }
}
