using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSWeb.Policy
{
    public class CustomAuthorizationRequirement : IAuthorizationRequirement
    {
        public string Name { get; set; }
        public CustomAuthorizationRequirement(string policyName)
        {
            this.Name = policyName;
        }
    }
}
