using FTask.AuthDatabase.Data;
using FTask.AuthServices.Helpers;
using FTask.Database.Models;
using FTask.Services.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Text;

namespace FTask.Api
{
    /// <summary>
    /// Config service and middleware
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Get configuration from appsettings files
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Config to connect with SQL Server
            services.AddDbContext<FTaskContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging(true);
            });

            // Config to connect with SQL Server Authentication
            services.AddDbContext<FTaskAuthDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AuthConnection"));
                options.EnableSensitiveDataLogging(true);
            });

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 5;
            })
                .AddEntityFrameworkStores<FTaskAuthDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Authentication:Jwt:Audience"],
                    ValidIssuer = Configuration["Authentication:Jwt:Issuer"],
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["Authentication:Jwt:Key"])),
                    ValidateIssuerSigningKey = true
                };
            });

            //======================================================================================
            services.AddControllers();
            services.AddCors();

            // Add API Versioning to the service container
            services.AddApiVersioning(options =>
            {
                // Specify the default API Version
                options.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                options.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new MediaTypeApiVersionReader("version"),
                    new HeaderApiVersionReader("api-version"));
            });

            // Setting json for PATCH Api...
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FTask.Api", Version = "v1" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "FTask.Api.xml");
                c.IncludeXmlComments(filePath);
            });

            // Config for AutoMapper...
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Register Service...
            services.InjectAuthServices();
            services.InjectServices();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FTask.Api v1"));

            }

            //Config for create log file...
            loggerFactory.AddFile(Configuration["Logging:PathFormat"]);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        }
    }
}
