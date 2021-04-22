using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using MvcWeb.Factory;
using MvcWeb.Service;
using MvcWeb.Utility;
using MvcWeb.Utility.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWeb.Controllers
{
    //[ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    //[TypeFilter(typeof(CustomExceptionFilterAttribute))]
    [CustomFilterFactory(typeof(CustomExceptionFilterAttribute))]
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> logger;
        private readonly IService service;
        public FirstController(ILogger<FirstController> logger, IService service)
        {
            this.logger = logger;
            this.service = service;
        }
        //[CustomExceptionFilterAttribute]
        [CustomActionFilterAttribute]
        //[CustomOrderedFilterAttribute(Order = 2)]
        [CustomResourceFilterAttribute]
        [CustomResultFilterAttribute]
        public IActionResult Index()
        {
            this.logger.LogInformation(service.GetName());
            //throw new Exception("first controller exception");
            //int i = 1;
            //i -= 1;
            //int result = 10 / i;
            return View();
        }
    }
}
