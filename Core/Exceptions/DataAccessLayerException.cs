using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class DataAccessLayerException: CoreException
    {
        public DataAccessLayerException() : base() { }
        public DataAccessLayerException(string message) : base(message) { }
        public DataAccessLayerException(string message, Exception inner) : base(message, inner) { }
    }
}
