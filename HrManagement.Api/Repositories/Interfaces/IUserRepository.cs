using HrManagement.Api.Entities;

namespace HrManagement.Api.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByUsernameAsync(string email);
    Task<User?> GetUserByIdAsync(int id);
    
}