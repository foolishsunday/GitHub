using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Core.Middleware
{
    public class DiyMiddleware
    {
        private readonly RequestDelegate _next;
        public DiyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"{DateTime.Now.ToString()}请求了方法");
            await _next.Invoke(context);
            Console.WriteLine($"{DateTime.Now.ToString()}响应了方法");
        }
    }
}
