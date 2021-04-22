using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWeb.Utility.Filter
{
    //特性，给Order赋值
    public class CustomOrderedFilterAttribute : Attribute, IActionFilter, IFilterMetadata, IOrderedFilter
    {
        public int Order { get; set; }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(Order==1)
                Console.WriteLine("123!");
            else
                Console.WriteLine("321!");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (Order == 1)
                Console.WriteLine("456!");
            else
                Console.WriteLine("654!");
        }
    }
}
