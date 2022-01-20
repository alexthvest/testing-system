namespace TestingSystem.Domain.Entities;

public class Group : Entity<Guid>
{
    public int Number { get; init; }
    
    public int Year { get; init; }

    public int Course => DateTime.UtcNow.Year - Year;

    public IReadOnlyCollection<Student> Students { get; init; } = Array.Empty<Student>();
}
