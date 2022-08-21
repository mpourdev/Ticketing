using Ticketing.EndPoints.API.ExceptionHandlers;

namespace Ticketing.EndPoints.API
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder application, ILogger logger)
        {
            application.UseExceptionHandler(ab => ApiExceptionHandler.Handler(ab, logger));
        }

        public static void UseCustomDeveloperExceptionHandler(this IApplicationBuilder application, ILogger logger)
        {
            application.UseExceptionHandler(ab => ApiExceptionHandler.DeveloperHandler(ab, logger));
        }

        public static void AddDefaultCors(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedHosts = configuration["AllowedHosts"].Split(",");
            services.AddCors(o => o.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins(allowedHosts)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));
        }
    }
}