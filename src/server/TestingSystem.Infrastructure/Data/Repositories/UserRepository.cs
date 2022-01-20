using Microsoft.EntityFrameworkCore;
using TestingSystem.Domain.Entities;
using TestingSystem.Domain.Repositories;

namespace TestingSystem.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> AddAsync(User user, CancellationToken cancellationToken = default)
    {
        var document = await _context.AddAsync(user, cancellationToken);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return document.Entity;
    }

    public async Task<User?> FindByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await _context.Accounts
            .FirstOrDefaultAsync(account => account.Username == username, cancellationToken);
    }
}
