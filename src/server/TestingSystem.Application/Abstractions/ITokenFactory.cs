using System.Security.Claims;

namespace TestingSystem.Application.Abstractions;

public interface ITokenFactory
{
    string Create(IEnumerable<Claim> claims);
}
