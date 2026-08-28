using HrManagement.Api.DTOs;
using HrManagement.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        string? token = await authService.LoginUserAsync(loginRequest.Username, loginRequest.Password);

        if (string.IsNullOrEmpty(token))
        {
            return Unauthorized("Authentication failed");
        }
        return Ok(new LoginResponse(token));

    }
    
    
    // [HttpPost("hash-test/{password}")]
    // public IActionResult HashTest( string password)
    // {
    //     return Ok(BCrypt.Net.BCrypt.HashPassword(password));
    // }
    
    
    
}