using FTask.Data.Repositories;
using FTask.Data.Repositories.IRepository;
using FTask.Services.MajorBusinessService;
using FTask.Services.StudentBusinessService;
using FTask.Services.SubjectGroupBusinessService;
using Microsoft.Extensions.DependencyInjection;

namespace FTask.Services.DependencyInjection
{
    public static class DependencyInjectionResolverGen
    {
        public static void IntializerDI(this IServiceCollection services)
        {
            // config for service for student         
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();

            // config for service for major         
            services.AddScoped<IMajorRepository, MajorRepository>();
            services.AddScoped<IMajorService, MajorService>();

            // config for service for SubjectGroup         
            services.AddScoped<ISubjectGroupRepository, SubjectGroupRepository>();
            services.AddScoped<ISubjectGroupService, SubjectGroupService>();
        }
    }
}
