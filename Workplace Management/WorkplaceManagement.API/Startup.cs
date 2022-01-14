using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System.IO;
using WorkplaceManagement.API.Extensions;
using WorkplaceManagement.LoggerService;
using WorkplaceManagement.Service.Extensions;
using WorkplaceManagement.Service.Service.Implementation;

namespace WorkplaceManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();

            services.ConfigureIISIntegration();

            services.ConfigureSwagger();

            services.ConfigureLoggerService();

            services.ConfigureSqlContext(Configuration);

            services.ConfigureRepositoryManager();

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddAutoMapper(typeof(SiteService)); // assembly where automaper is used

            services.ConfigureServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Workplace Management API v1"));
            }
            else
            {
                app.UseHsts();
            }

            app.ConfigureExceptionHandler(logger);

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
