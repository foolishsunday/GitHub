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

            //IOC��1.���� 2.����ϸ�ڡ�DI����ע�룬��ʵ��IOC���ֶΡ�DI������������Զ��������Ķ������ɲ����룬֧�ֵݹ����޼��ġ� IOC��Ŀ�꣬DI���ֶΡ�
            //����->ʵ��->ע��->ʹ��
            //�ӿ�->��->AddTransient->����service.����
            //����ע�룬��ӽӿڷ���
            services.AddTransient<IService, TestService>();



            //AOP����쳣����ȫ��ע�ᣬȫ����������ȫ��Action����Ч
            //���Բ��ܴ��ݱ���
            //���ַ�����1.ֱ�������� 2.�����õ�ServiceFilter(����ConfigureServices) 3.ȫ��ע��AddControllersWithViews 4.TypeFilter(����ע��) 5.CustomFilterFactoryAttribute
            //services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(typeof(CustomExceptionFilterAttribute));
            //});

            //AOP�������ServiceFilter�ķ������������һ��ʵ��ע��
            //services.AddTransient<CustomExceptionFilterAttribute>();

            //AOP: �����CustomFilterFactoryAttribute�������ע��
            //services.AddTransient<CustomFilterFactoryAttribute>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //�м���÷�
            //�κ��������ˣ�����
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

            app.UseAuthorization();//ʹ����Ȩ

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=First}/{action=Index}/{id?}");
            });

        }
    }
}
