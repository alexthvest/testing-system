namespace TestingSystem.Application.Requests;

public record CreateUserRequest(string Username, string FirstName, string LastName, string Role, string Password);
