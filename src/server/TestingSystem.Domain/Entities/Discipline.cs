namespace TestingSystem.Domain.Entities;

public class Discipline : Entity<Guid>
{
    public string Name { get; init; } = default!;

    public Teacher Teacher { get; init; } = default!;
}
