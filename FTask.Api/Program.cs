using FTask.AuthDatabase.Data;
using FTask.AuthServices.Helpers;
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
                    var authContext = services.GetRequiredService<FTaskAuthDbContext>();
                    if (env.IsStaging() || env.IsDevelopment())
                    {
                        DBInitializer.Initialize(context);
                        AuthDBInitializer.Initialize(authContext);
                    }
                    if (env.IsProduction())
                    {
                        DBInitializer.Initialize(context);
                        AuthDBInitializer.Initialize(authContext);
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured creating the FTask and FTaskAuthDB databases!.");
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
