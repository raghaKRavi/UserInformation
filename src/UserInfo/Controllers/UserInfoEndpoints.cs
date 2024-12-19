using Microsoft.AspNetCore.Mvc;

using UserInfo.Filters;
using UserInfo.Models.Requests;
using UserInfo.Services;

namespace UserInfo.Controllers;

public static class UserInfoEndpoints
{
    public static void MapUserInfoEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("/api/userinfo").WithOpenApi();

        endpoints.MapPost("", Create)
            .WithSummary("create new user information")
            .AddEndpointFilter<ValidationFilters<UserInfoRequest>>();

        endpoints.MapGet("", GetAll)
            .WithName(nameof(GetAll))
            .WithSummary("Get all UUser Information");

        endpoints.MapGet("/{id}", GetById)
            .WithName(nameof(GetById))
            .WithSummary("Get User Information By Id");
    }
    
    private static async Task<IResult> Create(UserInfoRequest request, IUserInfoService service)
    {
        await service.CreateUser(request);
        return TypedResults.Ok(new {message = "created"});
    }
    
    public static async Task<IResult> GetById(int userId, IUserInfoService service)
    {
        var response = await service.GetUserById(userId);
        return TypedResults.Ok(response);
    }
    
    
    public static async Task<IResult> GetAll(IUserInfoService service)
    {
        var response = await service.GetAll();
        return TypedResults.Ok(response);
    }
}