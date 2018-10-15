using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Interceptors
{
    public class AddOptionRecompileInterceptor : DbCommandInterceptor
    {
        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            var context = interceptionContext.DbContexts.OfType<LearnDBContext>().FirstOrDefault();
            
            if (context == null)
                return;

            if (context.UseRecompileOption)
            {
                if ((command.CommandText.StartsWith("Select", StringComparison.OrdinalIgnoreCase)) && !command.CommandText.Contains("option(recompile)"))
                {
                    command.CommandText += " option(recompile)";
                }
            }
        }
    }
}
