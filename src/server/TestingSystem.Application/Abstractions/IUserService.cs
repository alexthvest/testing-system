using TestingSystem.Application.Common;
using TestingSystem.Application.Requests;
using TestingSystem.Application.Responses;

namespace TestingSystem.Application.Abstractions;

public interface IUserService
{
    Task<OperationResult<CreateUserResponse>> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken = default);

    Task<OperationResult<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
}
