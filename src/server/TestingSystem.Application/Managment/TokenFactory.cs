using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TestingSystem.Application.Abstractions;

namespace TestingSystem.Application.Managment;

internal class TokenFactory : ITokenFactory
{
    public string Create(IEnumerable<Claim> claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("r5i43po5if09ai3jtoiduafoi"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var securityToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: credentials,
            claims: claims
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
