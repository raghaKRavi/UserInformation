using Microsoft.EntityFrameworkCore;

using UserInfo.Data;
using UserInfo.Repositories;
using UserInfo.Repositories.Implementations;
using UserInfo.Services;
using UserInfo.Services.Implementations;

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
}

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();
{
    // configure request pipleline - middleware
    app.MapControllers();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
