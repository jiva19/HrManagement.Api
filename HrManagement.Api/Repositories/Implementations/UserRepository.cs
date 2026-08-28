using HrManagement.Api.Data;
using HrManagement.Api.Entities;
using HrManagement.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Api.Repositories.Implementations;

public class UserRepository(AppDbContext appDbContext ):IUserRepository
{
    public async Task<User?> GetUserByUsernameAsync(string email)
    {
        User? user = await appDbContext.Users.FirstOrDefaultAsync(x=>x.Username==email);
        return user;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        User? user = await appDbContext.Users.FirstOrDefaultAsync(x=>x.Id==id);
        return user;
    }
}