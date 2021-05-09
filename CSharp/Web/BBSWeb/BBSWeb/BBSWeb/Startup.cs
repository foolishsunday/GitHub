using BBSWeb.Entity;
using BBSWeb.Entity.Context;
using BBSWeb.Policy;
using BBSWeb.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSWeb
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

            services.AddControllers();//添加控制器
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BBSWeb", Version = "v1" });
            });
            var conn = Configuration.GetConnectionString("MockDb");
            
            services.AddDbContext<AppDbContext>(options => options.UseMySql(conn, ServerVersion.AutoDetect(conn)));
            services.AddTransient<StudentService>();
            //services.AddSingleton<IAuthorizationHandler, CustomAuthorizationHandler>();//策略授权
            //services.AddScoped(typeof(IServiceInfo<>), typeof(BaseService<>));
            //services.AddControllersWithViews().AddXmlSerializerFormatters();
            //services.AddScoped<IStudentRepository, MockStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)//配置中间件：用起来
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();//使用Swagger
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BBSWeb v1"));//使用Swagger的UI
            }

            app.UseRouting();

            app.UseAuthentication();//使用权限验证,先开启认证
            app.UseAuthorization();// 然后是授权中间件
            app.UseEndpoints(endpoints =>//使用接入点
            {
                endpoints.MapControllers();
            });
            context.Database.EnsureCreated();//数据库不存在，则自动创建
        }
    }
}
