using Microsoft.EntityFrameworkCore;

namespace UserInfo.Data;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
    }
    
    public DbSet<UserInfoEntity> UserInfo { get; set; }
}