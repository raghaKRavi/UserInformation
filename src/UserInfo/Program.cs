using FluentValidation;

using Microsoft.EntityFrameworkCore;

using UserInfo.Data;
using UserInfo.Repositories;
using UserInfo.Repositories.Implementations;
using UserInfo.Services;
using UserInfo.Services.Implementations;
using FluentValidation;

using UserInfo.Controllers;

var builder = WebApplication.CreateBuilder(args);
{
    // DI IOC Container Configurations
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
    });
    
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddScoped<IUserInfoService, UserInfoService>();
    builder.Services.AddScoped<IUserInfoRepository, UserInfoRepository>();
    builder.Services.AddControllers();
    builder.Services.AddValidatorsFromAssemblyContaining<Program>();
}

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();
{
    // configure request pipleline - middleware
    app.MapControllers();
    app.MapUserInfoEndpoints();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
