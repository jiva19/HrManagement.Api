using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HrManagement.Api.Data;
using HrManagement.Api.Entities;
using HrManagement.Api.Repositories.Implementations;
using HrManagement.Api.Repositories.Interfaces;
using HrManagement.Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace HrManagement.Api.Services.Implementations;

public class AuthService(IUserRepository userRepository, IConfiguration configuration) : IAuthService
{
    public Task RegisterUser(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<string?> LoginUserAsync(string username, string password)
    {
        User? user = await userRepository.GetUserByUsernameAsync(username);
        if (user == null)
        {
            return null;
        }
        
        bool passwordVerification =  BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

        if (!passwordVerification)
        {
            return null;
        }
        
        return GenerateJwtToken(user);
    }
    
    

    private string GenerateJwtToken(User user)
    {
        List<Claim> claims =
        [   
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        ];

        string key = configuration["Jwt:Key"]!;
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(key));
        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}