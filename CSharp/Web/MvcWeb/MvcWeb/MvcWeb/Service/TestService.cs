using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWeb.Service
{
    public class TestService : IService
    {
        public string GetName()
        {
            Console.WriteLine("cim");
            return "cim";
        }

    }
}
