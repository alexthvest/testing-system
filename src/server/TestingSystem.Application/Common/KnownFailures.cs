using System.Net;

namespace TestingSystem.Application.Common;

public static class KnownFailures
{
    public static Failure InvalidUsernameOrPassword { get; } 
        = Failure.Create(HttpStatusCode.BadRequest, "Invalid username or password");
}
