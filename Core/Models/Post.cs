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

        public string Text { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public ICollection<Comment> Comments { get; set; }      
    }
}
