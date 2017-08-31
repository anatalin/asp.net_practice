using Services.Exceptions;
using Services.ProxyModels;
using Services.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace LearnWebApplication.Filters
{
    public class ModelExceptionAttribute : Attribute, IExceptionFilter
    {
        public bool AllowMultiple => true;

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception != null && actionExecutedContext.Exception is DbModelException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new Result<PostGetProxy>() { Data = null, Error = actionExecutedContext.Exception.Message, IsSuccess = false},
                    actionExecutedContext.ActionContext.ControllerContext.Configuration.Formatters.JsonFormatter);
            }
            return Task.FromResult<object>(null);
        }
    }
}