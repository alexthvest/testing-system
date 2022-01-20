namespace TestingSystem.Domain.Entities;

public class Teacher : User
{
    public IReadOnlyCollection<Discipline> Disciplines { get; init; } = Array.Empty<Discipline>();
}
