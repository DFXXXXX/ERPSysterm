using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ERPSysterm.Filters
{
        public class MyExceptionFilterAttribute : ExceptionFilterAttribute
        {
            public override void OnException(ExceptionContext context)
            {
                var knownException = context.Exception;
                if (knownException == null)
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }
                else
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
                }
            //  new ObjectResult(new { code = 404, sub_msg = "未找到资源", msg = "" });
            context.Result = new ObjectResult(new { code = 200, sub_msg = "参数错误", msg = "" });
       
                //ContentType = "application/json; charset=utf-8",
                //StatusCode =200,
                //Value ="Server Error"
                //};
            }
        }

}
