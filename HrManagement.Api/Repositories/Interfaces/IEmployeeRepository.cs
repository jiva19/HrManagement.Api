using HrManagement.Api.Entities;

namespace HrManagement.Api.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> SearchEmployeesAsync(string? name, string?department);
    
    Task<List<Employee>> GetAllEmployeesAsync();
    Task<Employee?> GetEmployeeByIdAsync(int  id);
    Task<List<Employee>> GetEmployeesListByDepartmentAsync(string department);
    
    Task<List<Employee>> GetEmployeeListByNameAsync(string name);
    
    Task DeleteEmployeeAsync(Employee employee);
    
    Task CreateEmployeeAsync(Employee employee);
    
    
}