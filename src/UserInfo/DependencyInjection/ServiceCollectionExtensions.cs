using UserInfo.Repositories;
using UserInfo.Repositories.Implementations;
using UserInfo.Services;
using UserInfo.Services.Implementations;

namespace UserInfo.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserInfos(this IServiceCollection services)
    {
        services.AddScoped<IUserInfoService, UserInfoService>();
        services.AddScoped<IUserInfoRepository, UserInfoRepository>();
        return services;
    }

    public static IServiceCollection AddGlobalErrorHandling(this IServiceCollection services)
    {
        services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;
            };
        });
        return services;
    }
}