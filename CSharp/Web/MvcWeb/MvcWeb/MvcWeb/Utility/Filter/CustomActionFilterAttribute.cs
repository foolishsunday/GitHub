using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWeb.Utility.Filter
{
    //特性，方法执行前及方法执行后调用OnActionExecuting、OnActionExecuted
    public class CustomActionFilterAttribute : Attribute, IActionFilter, IFilterMetadata
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Method is called when executing!");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Method is called after executed!");
        }
    }
}
