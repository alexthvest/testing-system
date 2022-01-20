using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Application.Abstractions;
using TestingSystem.Application.Common;
using TestingSystem.Application.Requests;
using TestingSystem.Application.Responses;

namespace TestingSystem.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<OperationResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        return await _userService.CreateAsync(request, cancellationToken);
    }
}
