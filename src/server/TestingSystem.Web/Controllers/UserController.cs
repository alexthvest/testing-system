using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Application.Abstractions;
using TestingSystem.Application.Common;
using TestingSystem.Application.Requests;
using TestingSystem.Application.Responses;
using TestingSystem.Domain.Repositories;

namespace TestingSystem.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;

    public UserController(IUserService userService, IUserRepository userRepository)
    {
        _userService = userService;
        _userRepository = userRepository;
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<OperationResult<LoginResponse>> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        return await _userService.LoginAsync(request, cancellationToken);
    }

    [HttpGet]
    [Authorize]
    public async Task<OperationResult<CreateUserResponse>> GetUser()
    {
        if (User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name) is not { Value: var username })
        {
            return KnownFailures.InvalidUsernameOrPassword;
        }

        var account = await _userRepository.FindByUsernameAsync(username);
        if (account is null)
        {
            return KnownFailures.InvalidUsernameOrPassword;
        }
        
        return new CreateUserResponse(account.Id, account.Username, account.FirstName, account.LastName);
    }
}
