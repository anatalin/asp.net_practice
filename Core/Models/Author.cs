using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }

        public ICollection<Post> Posts { get; set; }

    }
}
