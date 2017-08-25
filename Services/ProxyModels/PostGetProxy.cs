using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProxyModels
{
    public class PostGetProxy
    {
        public int PostId { get; set; }
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
    }
}
