using ERPSysterm.Utility;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSysterm.Filters
{
    public class ApiLogFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string actionArguments  = Newtonsoft.Json.JsonConvert.SerializeObject(context.ActionArguments);

            var resultContext = await next();

            string url = resultContext.HttpContext.Request.Host + resultContext.HttpContext.Request.Path + resultContext.HttpContext.Request.QueryString;

            string method = resultContext.HttpContext.Request.Method;

            //dynamic result = resultContext.Result.GetType().Name == "EmptyResult" ? new { Value = "EmptyResult" } : resultContext.Result as dynamic;

            string response = JsonConvert.SerializeObject(resultContext.Result);

             Log4netHelper.Info($"URL：{url} \n " +
                                  $"Method：{method} \n " +
                                  $"ActionArguments：{actionArguments}\n " +
                                  $"Response：{response}\n ");
        }
    }
}
