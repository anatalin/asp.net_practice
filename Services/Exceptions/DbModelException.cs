using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class DbModelException: ServicesException
    {
        public DbModelException() : base() { }
        public DbModelException(string message) : base(message) { }
        public DbModelException(string message, Exception inner) : base(message, inner) { }
    }
}
