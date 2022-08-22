using Microsoft.AspNetCore.Diagnostics;
using System.Text;
using Ticketing.Core.Domain.Shared.Exceptions;

namespace Ticketing.EndPoints.API.ExceptionHandlers;

internal static class ApiExceptionHandler
{
    public static void Handler(IApplicationBuilder ab, ILogger logger)
    {
        ab.Run(async context =>
        {
            context.Response.ContentType = "text/plain; charset=utf-8";
            var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;

            if (exception is IException customException)
            {
                context.Response.StatusCode = customException.Code;
                await context.Response.WriteAsync(customException.Message, Encoding.UTF8);
            }
            else
            {
                if (context.Response.StatusCode == 500)
                {
                    context.Response.StatusCode = GeneralException.CODE;
                    await context.Response.WriteAsync("Sorry we could not complete your request.", Encoding.UTF8);
                }
                else
                {
                    await context.Response.WriteAsync(exception?.Message?? "Sorry we could not complete your request.", Encoding.UTF8);
                }
            }

            logger.LogError($"Exception: {exception}");
        });
    }

    public static void DeveloperHandler(IApplicationBuilder ab, ILogger logger)
    {
        ab.Run(async context =>
        {
            context.Response.ContentType = "text/plain; charset=utf-8";
            var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;

            if (exception is IException customException)
            {
                context.Response.StatusCode = customException.Code;
            }

            if (exception is not null)
                await context.Response.WriteAsync(exception.ToString(), Encoding.UTF8);

            logger.LogError($"Exception: {exception}");
        });
    }
}