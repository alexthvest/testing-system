using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TestingSystem.Application.Abstractions;
using TestingSystem.Application.Managment;
using TestingSystem.Application.Services;
using TestingSystem.Domain.Entities;

namespace TestingSystem.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        services.AddScoped<IUserService, UserService>();

        services.AddScoped<ITokenFactory, TokenFactory>();
    }
}
