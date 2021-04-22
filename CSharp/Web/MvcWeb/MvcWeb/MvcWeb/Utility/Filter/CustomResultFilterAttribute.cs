using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWeb.Utility.Filter
{
    //Result是在视图替换前后
    public class CustomResultFilterAttribute : Attribute, IResultFilter, IFilterMetadata
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("Result executing!");
            
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("Result executed!");
        }
    }
}
