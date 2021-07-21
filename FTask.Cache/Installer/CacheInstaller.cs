using FTask.Cache.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace FTask.Cache.Installer
{
    public static class CacheInstaller
    {
        public static void InstallCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheSettings = new RedisCacheSettings();
            configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSettings);
            services.AddSingleton(redisCacheSettings);

            if (!redisCacheSettings.Enabled)
            {
                return;
            }
            // Config for health check
            services.AddSingleton<IConnectionMultiplexer>(_ => 
                ConnectionMultiplexer.Connect(redisCacheSettings.ConnectionString));

            services.AddStackExchangeRedisCache(options =>
                options.Configuration = redisCacheSettings.ConnectionString);

            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}
