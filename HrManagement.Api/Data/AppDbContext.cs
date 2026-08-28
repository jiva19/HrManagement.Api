using HrManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
}