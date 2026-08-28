namespace HrManagement.Api.Services.Interfaces;

public interface IAuthService
{
    Task RegisterUser(string username, string password);
    
    Task<string?> LoginUserAsync(string username, string password);
    
}