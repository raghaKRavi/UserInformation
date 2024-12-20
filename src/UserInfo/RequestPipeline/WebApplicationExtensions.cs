using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;

using UserInfo.Errors;

namespace UserInfo.RequestPipeline;

public static class WebApplicationExtensions
{
    public static WebApplication UseGlobalErrorHandling(this WebApplication app)
    {
        app.UseExceptionHandler("/error");

        app.Map("/error", (HttpContext httpContext) =>
        {
            Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            
            var loggerFactory = httpContext.RequestServices.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("GlobalErrorHandling");

            if (exception is null)
            {
                return Results.Problem();
            }

            if (exception is ServiceException se)
            {
                logger.LogError(exception, "An unhandled exception occurred: {ErrorMessage}", se.ErrorMessage);
            }
            
            return exception switch
            {
                ServiceException serviceException => 
                    Results.Problem(statusCode: serviceException.StatusCode, detail: serviceException.ErrorMessage),
                    _ => Results.Problem()
            };
        });
        return app;
    }
}