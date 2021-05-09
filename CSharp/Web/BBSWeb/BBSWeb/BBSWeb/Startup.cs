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

            services.AddControllers();//��ӿ�����
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BBSWeb", Version = "v1" });
            });
            var conn = Configuration.GetConnectionString("MockDb");
            
            services.AddDbContext<AppDbContext>(options => options.UseMySql(conn, ServerVersion.AutoDetect(conn)));
            services.AddTransient<StudentService>();
            //services.AddSingleton<IAuthorizationHandler, CustomAuthorizationHandler>();//������Ȩ
            //services.AddScoped(typeof(IServiceInfo<>), typeof(BaseService<>));
            //services.AddControllersWithViews().AddXmlSerializerFormatters();
            //services.AddScoped<IStudentRepository, MockStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)//�����м����������
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();//ʹ��Swagger
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BBSWeb v1"));//ʹ��Swagger��UI
            }

            app.UseRouting();

            app.UseAuthentication();//ʹ��Ȩ����֤,�ȿ�����֤
            app.UseAuthorization();// Ȼ������Ȩ�м��
            app.UseEndpoints(endpoints =>//ʹ�ý����
            {
                endpoints.MapControllers();
            });
            context.Database.EnsureCreated();//���ݿⲻ���ڣ����Զ�����
        }
    }
}
