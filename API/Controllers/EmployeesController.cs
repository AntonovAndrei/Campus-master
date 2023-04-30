using Application.Common.Pagination;
using Application.Users.Employees;
using Application.Users.Employees.Commands.Create;
using Application.Users.Employees.Commands.Delete;
using Application.Users.Employees.Commands.Update;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EmployeesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetEmployees([FromQuery]PagingParams param)
    {
        throw new NotImplementedException();
        //return HandleResult(await Mediator.Send(employee GetEmployeesListQuery {Params = param}));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateEmployees(CreateEmployeeDto employeeDto)
    {
        return HandleResult(await Mediator.Send(new CreateEmployeeCommand {EmployeeDto = employeeDto}));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployees(Guid id, CreateEmployeeDto employeeDto)
    {
        employeeDto.Id = id;
        return HandleResult(await Mediator.Send(new UpdateEmployeeCommand {EmployeeDto = employeeDto}));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployees(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteEmployeeCommand {EmployeeId = id}));
    }
}