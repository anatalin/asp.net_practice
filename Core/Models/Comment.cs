using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string CommentText { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
