using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Results
{
    public class Result<T>
    {
        public bool IsSuccess
        {
            get
            {
                return (String.IsNullOrEmpty(Error)) ? true : false;
            }
        }
        public string Error { get; set; }
        public T Data { get; set; }
    }
}
