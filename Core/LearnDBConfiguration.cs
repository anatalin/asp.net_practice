using Core.Interceptors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class LearnDBConfiguration: DbConfiguration
    {
        public LearnDBConfiguration()
        {
            this.AddInterceptor(new AddOptionRecompileInterceptor());
        }
    }
}
