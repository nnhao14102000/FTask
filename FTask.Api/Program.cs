using FTask.Database.Models;
using FTask.Services.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace FTask.Api
{
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Run api if Db is existed...if not will be create Db and run
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var env = services.GetRequiredService<IWebHostEnvironment>();
                    var context = services.GetRequiredService<FTaskContext>();
                    if (env.IsStaging() || env.IsDevelopment())
                    {
                        DBInitializer.Initialize(context);
                    }
                    if (env.IsProduction())
                    {
                        //DBInitializer.Initialize(context);
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured creating the CloudDB.");
                }
            }
        }
        /// <summary>
        /// Use config in Startup class to create host
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
