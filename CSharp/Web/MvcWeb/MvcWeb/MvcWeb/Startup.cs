using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcWeb.Factory;
using MvcWeb.Service;
using MvcWeb.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //IOC：1.解耦 2.屏蔽细节。DI依赖注入，是实现IOC的手段。DI：构造对象，能自动把依赖的对象生成并传入，支持递归无限级的。 IOC是目标，DI是手段。
            //抽象->实现->注册->使用
            //接口->类->AddTransient->调用service.方法
            //依赖注入，添加接口服务
            services.AddTransient<IService, TestService>();



            //AOP添加异常处理，全局注册，全部控制器、全部Action都生效
            //特性不能传递变量
            //五种方法：1.直接用特性 2.用内置的ServiceFilter(必须ConfigureServices) 3.全局注册AddControllersWithViews 4.TypeFilter(无需注册) 5.CustomFilterFactoryAttribute
            //services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(typeof(CustomExceptionFilterAttribute));
            //});

            //AOP：如果用ServiceFilter的方法，必须添加一下实例注册
            //services.AddTransient<CustomExceptionFilterAttribute>();

            //AOP: 如果用CustomFilterFactoryAttribute，则必须注册
            //services.AddTransient<CustomFilterFactoryAttribute>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //中间件用法
            //任何请求来了，返回
            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        await context.Response.WriteAsync("Hello");
            //    };
            //});
            //app.Use(next =>
            //{
            //    Console.WriteLine("999");
            //    return new RequestDelegate(
            //        async context =>
            //        {
            //            await context.Response.WriteAsync("Hello levi" + Environment.NewLine);
            //            await next.Invoke(context);
            //            await context.Response.WriteAsync("Start two" + Environment.NewLine);
            //        });
            //});
            //app.Use(next =>
            //{
            //    Console.WriteLine("888");
            //    return new RequestDelegate(
            //        async context =>
            //        {
            //            await context.Response.WriteAsync("I am 33 years old" + Environment.NewLine);
            //            await next.Invoke(context);
            //            await context.Response.WriteAsync("Start 3" + Environment.NewLine);
            //        });
            //});
            //app.Use(next =>
            //{
            //    Console.WriteLine("123");
            //    return new RequestDelegate(
            //        async context =>
            //        {
            //            await context.Response.WriteAsync("I am guangdong ren" + Environment.NewLine);
            //            //await next.Invoke(context);
            //            await context.Response.WriteAsync("engineer" + Environment.NewLine);
            //        });
            //});



            //app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.Use(next =>
            //{
            //    return async c =>
            //    {
            //        if (c.Request.Query.ContainsKey("Name"))
            //            await next.Invoke(c);
            //        else
            //            await c.Response.WriteAsync("No Auth");
            //    };
            //});

            app.UseAuthorization();//使用授权

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=First}/{action=Index}/{id?}");
            });

        }
    }
}
