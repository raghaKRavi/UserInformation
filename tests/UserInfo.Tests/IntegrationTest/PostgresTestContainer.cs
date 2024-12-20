
using TestContainers.Container.Abstractions.Hosting;
using TestContainers.Container.Database.Hosting;
using TestContainers.Container.Database.PostgreSql;
using UserInfo.Data;
using UserInfo.Models.Entities;

namespace UserInfo.Tests.IntegrationTest;

public class PostgresTestContainer : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgresContainer;
    
    public PostgresTestContainer()
    {
        _postgresContainer = new ContainerBuilder<PostgreSqlContainer>()
            .ConfigureDatabaseConfiguration("user", "pass", "docosoft")
            .Build();
    }
    
    public async Task InitializeAsync()
    {
        await _postgresContainer.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _postgresContainer.StopAsync();
    }

    public string GetConnectionString()
    {
        return _postgresContainer.GetConnectionString();
    }
}