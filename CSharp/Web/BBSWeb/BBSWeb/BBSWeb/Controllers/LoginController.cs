using BBSWeb.Entity;
using BBSWeb.Entity.Context;
using BBSWeb.Filters;
using BBSWeb.Repository;
using DbFirst.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSWeb.Controllers
{
    [Route("[controller]/[action]")]//   从路由体现行为：/Login/Get、/Login/Insert、/Login/Update、/Login/Remove，即RESTful风格
    [ApiController]
    public class LoginController : ControllerBase
    {

        //private readonly StudentService _studentService;
        //private readonly IProductService _productService;
        public LoginController()//(IProductService productService)
        {
            //_studentService = studentService;
            //_productService = productService;
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomActionFilterAttribute))]
        //[Authorize]
        public string Get(string userName, string password)
        {
            //var stu = _studentService.GetInfo().Where(x=>x.Id==2).FirstOrDefault();
            //string text = string.Format($"id = {stu.Id}, name = {stu.Name}");
            //var p = _productService.QueryAll().Single(x => x.Id == 4);
            //string text = string.Format($"id = {p.Id}, name = {p.Name}");
            return "abcd";
        }

        //同时存在两个get时，添加路由
        [HttpGet("{userNo}/{password}")]
        public Student GetOne(string userNo, string password)
        {
            return new Student() { Id = 3, Name = "C", Major = "HK" };
        }
        [HttpPost]
        public string Login(string name, string password)
        {
            return "这是post";
        }

        [HttpPut]
        public string Update()
        {
            return "Update中";
        }
        [HttpDelete]
        public string Remove()
        {
            return "Remove了";
        }
    }
}
