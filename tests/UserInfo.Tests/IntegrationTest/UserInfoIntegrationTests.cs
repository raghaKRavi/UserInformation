using System.Text.Json;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;

using Newtonsoft.Json;

using Npgsql;

using UserInfo.Data;
using UserInfo.Models.Entities;
using UserInfo.Models.Responses;

namespace UserInfo.Tests.IntegrationTest;

public class UserInfoIntegrationTests : 
    IClassFixture<PostgresTestContainer>, IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;
    private readonly PostgresTestContainer _postgresTestContainer;
    private readonly DbContextOptions<AppDbContext> _dbContextOptions;
    
    public UserInfoIntegrationTests(PostgresTestContainer postgresTestContainer, WebApplicationFactory<Program> factory)
    {
        _postgresTestContainer = postgresTestContainer;
        _httpClient = factory.CreateClient();
        
        _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(_postgresTestContainer.GetConnectionString())
            .Options;
    }
    [Fact]
    public async Task GetById_ShouldReturnUserInfo_WhenUserExist()
    {
        var dbContext = new AppDbContext(_dbContextOptions);
        await dbContext.Database.MigrateAsync();
        
        var userInfo = new UserInfoEntity
        {
            Email = "r@g.com",
            FirstName = "John",
            LastName = "Doe",
            Dob = DateOnly.FromDateTime(DateTime.Now),
        };
        
        await dbContext.UserInfo.AddAsync(userInfo);
        await dbContext.SaveChangesAsync();
        
        var insertedUser = await dbContext.UserInfo
            .FirstOrDefaultAsync(u => u.Id == 1);

        Assert.NotNull(insertedUser);
        Assert.Equal(1, insertedUser.Id);
        Assert.Equal("r@g.com", insertedUser.Email);
        
        var response = await _httpClient.GetAsync("/api/userinfo/1");
        
        response.EnsureSuccessStatusCode();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var user = JsonConvert.DeserializeObject<UserInfoResponse>(jsonResponse);
        
        Assert.NotNull(user);
        Assert.Equal("string", user.Email);
        Assert.Equal("string string", user.Name);
    }

}