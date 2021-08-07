using Ly.Core.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Core
{
    public static partial class Extensions
    {
        public static IApplicationBuilder UseDiyLog(this IApplicationBuilder app)
        {
            return app.UseMiddleware<DiyMiddleware>();
        }
    }
}
