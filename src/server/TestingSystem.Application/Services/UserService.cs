using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using TestingSystem.Application.Abstractions;
using TestingSystem.Application.Common;
using TestingSystem.Application.Requests;
using TestingSystem.Application.Responses;
using TestingSystem.Domain.Entities;
using TestingSystem.Domain.Repositories;

namespace TestingSystem.Application.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenFactory _tokenFactory;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(
        IUserRepository userRepository,
        ITokenFactory tokenFactory,
        IPasswordHasher<User> passwordHasher
    )
    {
        _userRepository = userRepository;
        _tokenFactory = tokenFactory;
        _passwordHasher = passwordHasher;
    }

    public async Task<OperationResult<CreateUserResponse>> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        var account = await _userRepository.FindByUsernameAsync(request.Username, cancellationToken);
        if (account is not null)
        {
            return Failure.Create(HttpStatusCode.BadRequest, "Failed to create user");
        }

        var (username, firstName, lastName, role, password) = request;
        var passwordHash = _passwordHasher.HashPassword(null!, password);

        account = new User
        {
            Username = username,
            FirstName = firstName,
            LastName = lastName,
            Role = role.ToLowerInvariant(),
            PasswordHash = passwordHash
        };

        var entity = await _userRepository.AddAsync(account, cancellationToken);
        return new CreateUserResponse(entity.Id, entity.Username, entity.FirstName, entity.LastName);
    }

    public async Task<OperationResult<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var account = await _userRepository.FindByUsernameAsync(request.Username, cancellationToken);
        if (account is null)
        {
            return KnownFailures.InvalidUsernameOrPassword;
        }

        if (_passwordHasher.VerifyHashedPassword(null!, account.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
        {
            return KnownFailures.InvalidUsernameOrPassword;
        }

        var token = _tokenFactory.Create(new Claim[]
        {
            new(ClaimTypes.Name, account.Username),
            new(ClaimTypes.Role, account.Role)
        });
        
        return new LoginResponse(token);
    }
}
