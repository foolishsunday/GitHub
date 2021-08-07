using EFCore.Sharding;
using Ly.Core;
using Ly.Core.Primitives;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((host, services) =>
                {
                    services.AddFxServices();
                    services.AddAutoMapper();
                    services.AddEFCoreSharding(config =>
                    {
                        config.SetEntityAssemblies(GlobalAssemblies.AllAssemblies);

                        var dbOptions = host.Configuration.GetSection("Database:BaseDb").Get<DatabaseOptions>();

                        config.UseDatabase(dbOptions.ConnectionString, dbOptions.DatabaseType);
                    });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
