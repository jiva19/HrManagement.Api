using HrManagement.Api.Data;
using HrManagement.Api.Entities;
using HrManagement.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Api.Repositories.Implementations;

public class EmployeeRepository(AppDbContext appDbContext): IEmployeeRepository
{
    public async Task<List<Employee>> SearchEmployeesAsync(string? name, string? department)
    {

        IQueryable<Employee> query = appDbContext.Employees;

        
        if (!string.IsNullOrEmpty(name))
        {
            query =  query.Where(x=>x.Name.Contains(name));
        }

        if (!string.IsNullOrEmpty(department))
        {
            query = query.Where(x => x.Department == department);
        }
        
        return await query.ToListAsync();
        
        
    }

    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        return await appDbContext.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        Employee? employee = await appDbContext.Employees.FirstOrDefaultAsync(x=>x.Id == id);
        return employee;
    }

    public async Task<List<Employee>> GetEmployeesListByDepartmentAsync(string department)
    {
        List<Employee> listEmployees = await appDbContext.Employees.Where(x=>x.Department==department).ToListAsync();
        return listEmployees;
    }

    public async Task<List<Employee>> GetEmployeeListByNameAsync(string name)
    {
        List<Employee> employee = await appDbContext.Employees.Where(x=> x.Name.Contains(name)).ToListAsync();
        return employee;
    }

    public async Task DeleteEmployeeAsync(Employee employee)
    {
        appDbContext.Employees.Remove(employee);
        await appDbContext.SaveChangesAsync();
    }

    public async Task CreateEmployeeAsync(Employee employee)
    {
        await appDbContext.Employees.AddAsync(employee);
        await appDbContext.SaveChangesAsync();
    }
}