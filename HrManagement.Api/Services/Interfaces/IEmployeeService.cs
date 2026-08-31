using HrManagement.Api.Entities;

namespace HrManagement.Api.Services.Interfaces;

public interface IEmployeeService
{
    
    Task<List<Employee>> SearchEmployeesAsync(string? name,string? department);
    
    Task<bool> DeleteEmployeeByIdAsync(int id);
    
    Task CreateEmployeeAsync(string name, string department);
    
    
}