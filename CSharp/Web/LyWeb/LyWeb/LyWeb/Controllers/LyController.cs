using Ly.Entity;
using Ly.IBusiness;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyWeb.Controllers
{
    [Route("[controller]/[action]")]
    public class LyController : Controller
    {
        private readonly IBase_SchoolBusiness _base_SchoolBusiness;
        public LyController(IBase_SchoolBusiness base_SchoolBusiness)
        {
            _base_SchoolBusiness = base_SchoolBusiness;
        }
        [HttpGet]
        public async Task<Base_School> GetSchool()
        {
            var temp = await _base_SchoolBusiness.GetSchool(1);
            return temp;
        }
    }
}
