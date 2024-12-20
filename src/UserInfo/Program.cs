using FluentValidation;

using Microsoft.EntityFrameworkCore;

using UserInfo.Data;
using UserInfo.Repositories;
using UserInfo.Repositories.Implementations;
using UserInfo.Services;
using UserInfo.Services.Implementations;
using FluentValidation;

using UserInfo.Controllers;
using UserInfo.DependencyInjection;
using UserInfo.RequestPipeline;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
    });
    
    
    builder.Services
        .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
        .AddValidatorsFromAssemblyContaining<Program>()
        .AddGlobalErrorHandling()
        .AddUserInfos()
        .AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddControllers();
}

var app = builder.Build();
{
    app.UseGlobalErrorHandling();
    app.MapControllers();
    app.MapUserInfoEndpoints();
}


app.UseSwagger(); 
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();

public partial class Program { }