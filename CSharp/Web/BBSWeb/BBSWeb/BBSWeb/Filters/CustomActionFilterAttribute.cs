using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSWeb.Filters
{
    public class CustomActionFilterAttribute : Attribute, IActionFilter
    {
        //适用于log， 使用方法[TypeFilter(typeof(CustomActionFilterAttribute))]
        private ILogger<CustomActionFilterAttribute> _logger = null;
        public CustomActionFilterAttribute(ILogger<CustomActionFilterAttribute> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation(Newtonsoft.Json.JsonConvert.SerializeObject(context.HttpContext.Request.Query));
            _logger.LogInformation("CustomActionFilterAttribute.OnActionExecuting");
            Console.WriteLine("*******************************Test***********************************");
        }
        public void OnActionExecuted(ActionExecutedContext context)//方法执行后
        {
            _logger.LogInformation(Newtonsoft.Json.JsonConvert.SerializeObject(context.Result));
            _logger.LogInformation("CustomActionFilterAttribute.OnActionExecuting");
        }
    }
}
