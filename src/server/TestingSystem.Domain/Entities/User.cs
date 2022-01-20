namespace TestingSystem.Domain.Entities;

public class User : Entity<Guid>
{
    public string Username { get; init; } = default!;

    public string FirstName { get; init; } = default!;

    public string LastName { get; init; } = default!;

    public string Role { get; init; } = default!;

    public string PasswordHash { get; init; } = default!;
}
