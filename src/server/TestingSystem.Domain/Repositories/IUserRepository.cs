using TestingSystem.Domain.Entities;

namespace TestingSystem.Domain.Repositories;

public interface IUserRepository
{
    Task<User> AddAsync(User user, CancellationToken cancellationToken = default);

    Task<User?> FindByUsernameAsync(string username, CancellationToken cancellationToken = default);
}
