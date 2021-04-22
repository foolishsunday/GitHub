using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWeb.Utility
{
    //异常处理，AOP
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                Console.WriteLine("-------------Error-----------------------");
                context.Result = new JsonResult(new
                {
                    Result = false,
                    Msg = "please connect admin"

                });
                context.ExceptionHandled = true;//异常已被处理
            }
            base.OnException(context);
        }
    }
}
