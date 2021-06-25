using FTask.AuthServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FTask.AuthServices.Helpers
{
    public static class AuthServicesInjection
    {
        public static void InjectAuthServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
