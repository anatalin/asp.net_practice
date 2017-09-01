using Core.Exceptions;
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
            if (actionExecutedContext.Exception != null)
            {
                if (actionExecutedContext.Exception is NotFoundException)
                {
                    actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                        HttpStatusCode.BadRequest,
                        new Result<PostGetProxy>() { Error = actionExecutedContext.Exception.Message },
                        actionExecutedContext.ActionContext.ControllerContext.Configuration.Formatters.JsonFormatter);
                }
                else
                {
                    actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                        HttpStatusCode.BadRequest,
                        new Result<PostGetProxy>() { Error = "При обработке запроса что-то пошло не так." },
                        actionExecutedContext.ActionContext.ControllerContext.Configuration.Formatters.JsonFormatter);
                }
            }
            return Task.FromResult<object>(null);
        }
    }
}