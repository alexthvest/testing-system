using System.Net;

namespace TestingSystem.Application.Common;

public record struct Failure(HttpStatusCode StatusCode, string Message)
{
    public static Failure Create(HttpStatusCode statusCode, string message)
        => new(statusCode, message);
}
