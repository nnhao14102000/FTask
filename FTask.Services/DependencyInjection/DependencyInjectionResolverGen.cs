using FTask.Data.Repositories;
using FTask.Data.Repositories.IRepository;
using FTask.Services.MajorBusinessService;
using FTask.Services.SemesterBusinessService;
using FTask.Services.StudentBusinessService;
using FTask.Services.SubjectBusinessService;
using FTask.Services.SubjectGroupBusinessService;
using FTask.Services.TaskCategoryBusinessService;
using FTask.Services.TopicBusinessService;
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

            // config for service for Subject       
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ISubjectService, SubjectService>();

            // config for service for Semester       
            services.AddScoped<ISemesterRepository, SemesterRepository>();
            services.AddScoped<ISemesterService, SemesterService>();

            // config for service for TaskCategory       
            services.AddScoped<ITaskCategoryRepository, TaskCategoryRepository>();
            services.AddScoped<ITaskCategoryService, TaskCategoryService>();

            // config for service for Topic
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ITopicService, TopicService>();
        }
    }
}
