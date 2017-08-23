using Core;
using Core.Models;
using Core.Repositories;
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
                var postRepo = new PostRepository(context);
                

                //var coll = context.Posts;

                foreach (var i in postRepo.GetAll())
                {
                    this.richTextBox1.AppendText(i.PublishDate.ToString() + "\n");
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var postRepo = new PostRepository(context);

                postRepo.Add(new Post { PublishDate = DateTime.Now, Comments = new List<Comment> { new Comment { CommentText = "Comment from button" } } });

                context.SaveChanges();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var commentRepo = new CommentRepository(context);

                commentRepo.Add(1302, new Comment { CommentText = "This is comment for 1302 post", PostId = 1302});

                context.SaveChanges();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var postRepo = new PostRepository(context);

                postRepo.Delete(1);//(new Post { PostId = 1, PublishDate = Convert.ToDateTime("23.08.2017") });

                context.SaveChanges();
            }
        }
    }
}
