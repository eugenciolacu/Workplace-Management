using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using WorkplaceManagement.Dal.Repository.Implementation;
using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Context;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.LoggerService;
using WorkplaceManagement.Service.Service.Implementation;
using WorkplaceManagement.Service.Service.Interface;

namespace WorkplaceManagement.Service.Extensions
{
    public static class ServiceExtensions
    {
        // Use this to configure Cross-Origin Resource Sharing (CORS)
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy", builder =>
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
                });

        // Use this to configure swagger
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            var info = new OpenApiInfo()
            {
                Version = "v1",
                Title = "Workplace Management API",
                Description = "Workplace Management App API",
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", info);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(System.AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // Use this to configure IIS
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        // Register LoggerManager
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        // Register DbContext
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
                services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Register RepositoryManager 
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        // Register services
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ISiteService, SiteService>();
            services.AddScoped<IFloorService, FloorService>();
        }

        // configure identity
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 4;
                o.User.RequireUniqueEmail = true;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }
    }
}
