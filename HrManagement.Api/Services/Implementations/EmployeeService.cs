using HrManagement.Api.Entities;
using HrManagement.Api.Repositories.Interfaces;
using HrManagement.Api.Services.Interfaces;

namespace HrManagement.Api.Services.Implementations;

public class EmployeeService(IEmployeeRepository employeeRepository): IEmployeeService
{
    public async Task<List<Employee>> GetAllEmployeesByNameAsync(string? name)
    {
        List<Employee> employees;
        
        if (string.IsNullOrEmpty(name))
        {
            employees = await employeeRepository.GetAllEmployeesAsync();
        }
        else
        { 
          employees = await employeeRepository.GetEmployeeListByNameAsync(name);  
        }
        
        return employees;
    }

    public async  Task<bool> DeleteEmployeeByIdAsync(int id)
    {
        Employee? employee = await employeeRepository.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return false;
            
        }

        await employeeRepository.DeleteEmployeeAsync(employee);
        return true;

    }

    public async Task CreateEmployeeAsync(string name, string department)
    {
        Employee employee = new Employee
        {
            Name = name,
            Department = department
        };
        
        await employeeRepository.CreateEmployeeAsync(employee);
    }
}