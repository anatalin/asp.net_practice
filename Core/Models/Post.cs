using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Post
    {        
        public int PostId { get; set; }

        [Column(TypeName = "date")]
        public DateTime PublishDate { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Comments = new List<Comment>();
        }
    }
}
