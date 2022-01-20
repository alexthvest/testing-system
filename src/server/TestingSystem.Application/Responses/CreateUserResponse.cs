namespace TestingSystem.Application.Responses;

public record CreateUserResponse(Guid Id, string Username, string FirstName, string LastName);