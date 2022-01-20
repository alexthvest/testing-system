using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestingSystem.Domain.Repositories;
using TestingSystem.Infrastructure.Data;
using TestingSystem.Infrastructure.Data.Repositories;

namespace TestingSystem.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsql<ApplicationDbContext>(
            configuration.GetConnectionString("DefaultConnection"));

        services.AddScoped<IUserRepository, UserRepository>();
    }
}
