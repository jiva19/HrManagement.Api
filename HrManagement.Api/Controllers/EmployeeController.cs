using HrManagement.Api.DTOs;
using HrManagement.Api.Entities;
using HrManagement.Api.Services.Implementations;
using HrManagement.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EmployeeController(IEmployeeService employeeService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetEmployeesList([FromQuery] string? name,  [FromQuery] string? department)
    {
        List<Employee> employees = await employeeService.SearchEmployeesAsync(name, department);
        return Ok(employees);
    }
    
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveEmployee(int id)
    {
        bool response = await employeeService.DeleteEmployeeByIdAsync(id);
        if (!response)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] PostEmployee employee)
    {
        await employeeService.CreateEmployeeAsync(employee.Name, employee.Department);

        return Created();
    }
    
    
}