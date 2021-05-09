using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSWeb.Policy
{
    //注册：在ConfigureServices方法中， services.AddSingleton<IAuthorizationHandler, CustomAuthorizationHandler>();
    //使用方法： 在控制器里添加 [Authorize(policy:"PolicyStudent")]
    public class CustomAuthorizationHandler : AuthorizationHandler<CustomAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthorizationRequirement requirement)
        {
            if (requirement.Name == "PolicyStudent")
            {
                //策略1
            }
            else if (requirement.Name == "PolicyTeacher")
            { 
                //策略2
            }
            var role = context.User.FindFirst(c => c.Value.Contains("admin"));
            if (role != null)
                context.Succeed(requirement);//验证通过
            return Task.CompletedTask;//验证不通过
        }
    }
}
