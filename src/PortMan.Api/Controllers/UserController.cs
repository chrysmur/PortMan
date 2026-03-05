using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PortMan.Api.Authentication.helpers;
using PortMan.Application.Types;
using PortMan.Application.UserService;

namespace PortMan.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository) => _userRepository = userRepository;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        if (!Guid.TryParse(id, out Guid UserId) || string.IsNullOrEmpty(id))
        {
            return BadRequest(new { Error = "Invalid user ID format" });
        }

        var user = await _userRepository.GetUserByIdAsync(UserId, CancellationToken.None);
        if (user == null)
        {
            return NotFound(new
            {
                Error = "User not found"
            });
        }
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var authHeader = Request.Headers.Authorization.ToString();
        var tenantId = TokenParser.GetTenantId(authHeader);

        if (string.IsNullOrEmpty(tenantId))
        {
            return BadRequest(new { Error = "User creation failed. Invalid Tenant details" });
        }
        var users = await _userRepository.GetUsersByTenantIdAsync(tenantId, CancellationToken.None);
        return Ok(users);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username) ||
            string.IsNullOrWhiteSpace(request.Email) ||
            string.IsNullOrWhiteSpace(request.Password) ||
            string.IsNullOrWhiteSpace(request.Phone) ||
            string.IsNullOrWhiteSpace(request.TaxPin) ||
            string.IsNullOrWhiteSpace(request.Address))
        {
            return BadRequest(new { Error = "User creation failed. All fields are required" });
        }

        var authHeader = Request.Headers.Authorization.ToString();
        var tenantId = TokenParser.GetTenantId(authHeader);

        if (string.IsNullOrEmpty(tenantId))
        {
            return BadRequest(new { Error = "User creation failed. Invalid Tenant details" });
        }

        var user = await _userRepository.CreateUserAsync(
            request,
            tenantId,
            CancellationToken.None);
        return Ok(user);
    }
}
