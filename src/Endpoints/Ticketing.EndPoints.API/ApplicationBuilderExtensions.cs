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
    }
}