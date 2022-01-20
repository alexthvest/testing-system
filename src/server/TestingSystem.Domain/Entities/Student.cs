namespace TestingSystem.Domain.Entities;

public class Student : User
{
    public Group? Group { get; init; }
}