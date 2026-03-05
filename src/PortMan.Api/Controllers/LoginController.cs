using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortMan.Api.Authentication;
using PortMan.Api.Authentication.Types;
using PortMan.Application.UserService;

namespace PortMan.Api.Controllers;
[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILogin _loginUser;

    public AuthController(ILogin loginUser) => _loginUser = loginUser;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        LoginResult result = await _loginUser.LoginUserAsync(request.TenantId, request.Username, request.Password, CancellationToken.None);

        if (result.IsSuccess)
        {
            return Ok(new { result });
        }

        return Unauthorized(new { Error = result.ErrorMessage });
    }
}
