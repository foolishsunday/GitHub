using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWeb.Utility.Filter
{
    //构造函数构造之前
    //OnResourceExecuted：保存缓存结果
    //OnResourceExecuting：使用缓存

    public class CustomResourceFilterAttribute : Attribute, IResourceFilter, IFilterMetadata, IOrderedFilter
    {
        private static Dictionary<string, IActionResult> customCache = new Dictionary<string, IActionResult>();
        public int Order => 0;
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string key = context.HttpContext.Request.Path;
            if (customCache.ContainsKey(key))
                context.Result = customCache[key];//断路器：指定result后不往后走了
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            string key = context.HttpContext.Request.Path;
            customCache.Add(key, context.Result);//context.Result:上下文结果
        }
    }
}
