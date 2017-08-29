using Core.Interceptors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class HintExtension
    {
        public static DbSet<T> WithHint<T>(this DbSet<T> set, string hint) where T : class
        {
            //HintInterceptor.HintValue = hint;
            return set;
        }
    }
}
