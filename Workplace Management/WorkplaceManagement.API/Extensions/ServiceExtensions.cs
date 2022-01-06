using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using WorkplaceManagement.LoggerService;

namespace WorkplaceManagement.Service.Extensions
{
    public static class ServiceExtensions
    {
        // use this to configure Cross-Origin Resource Sharing (CORS)
        public static void ConfigureCors(this IServiceCollection services) => 
            services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy", builder =>
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
                });

        // use this to configure swagger
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

        // use this to configure IIS
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();
    }
}
