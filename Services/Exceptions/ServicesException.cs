using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class ServicesException: Exception
    {
        public ServicesException() : base() { }
        public ServicesException(string message) : base(message) { }
        public ServicesException(string message, Exception inner) : base(message, inner) { }
    }
}
