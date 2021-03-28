using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Autofac.Extensions.DependencyInjection;

namespace MvcWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logger) =>
                {
                    logger.AddFilter("System", LogLevel.Warning);
                    logger.AddFilter("Microsoft", LogLevel.Warning);
                    logger.AddLog4Net();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())//Autofac
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseKestrel(builder =>
                    //{
                    //    builder.Listen(IPAddress.Loopback, 12344);
                    //}).Configure(app => app.Run(async context =>
                    //  await context.Response.WriteAsync("Hello")))
                    //.UseIIS()
                    //.UseIISIntegration();
                    
                });
    }
}
