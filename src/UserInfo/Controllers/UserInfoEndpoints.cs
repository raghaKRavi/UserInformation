using Microsoft.AspNetCore.Mvc;

using UserInfo.Filters;
using UserInfo.Models.Requests;
using UserInfo.Models.Responses;
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

        endpoints.MapPut("{id}", UpdateById)
            .WithSummary("Update user information")
            .AddEndpointFilter<ValidationFilters<UserInfoRequest>>();
        
        endpoints.MapGet("", GetAll)
            .WithName(nameof(GetAll))
            .WithSummary("Get all User Information");

        endpoints.MapGet("{id}", GetById)
            .WithName(nameof(GetById))
            .WithSummary("Get User Information By Id");
    }
    
    private static async Task<IResult> Create(UserInfoRequest request, IUserInfoService service)
    {
        await service.CreateUser(request);
        return TypedResults.Ok(new {message = "created"});
    }
    
    private static async Task<IResult> UpdateById( [FromBody] UserInfoRequest request, [FromRoute(Name = "id")] int id, IUserInfoService service)
    {
        await service.UpdateUserInfo(id, request);
        return TypedResults.Ok("Updated");
    }
    
    private static async Task<IResult> GetById(int id, IUserInfoService service)
    {
        var response = await service.GetUserById(id);
        return TypedResults.Ok(response);
    }
    
    private static async Task<IResult> GetAll(IUserInfoService service)
    {
        var response = await service.GetAll();
        return TypedResults.Ok(response);
    }
}