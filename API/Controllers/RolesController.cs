using Application.Roles.Commands.AddRoleToEmployee;
using Application.Roles.Commands.AddRoleToResident;
using Application.Roles.Commands.DeleteRoleFromEmployee;
using Application.Roles.Commands.DeleteRoleFromResident;
using Application.Roles.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RolesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> RoleList()
    {
        return HandleResult(await Mediator.Send(new RoleListQuery()));
    }
    
    [HttpPost("{roleId}/employee/{employeeId}")]
    public async Task<IActionResult> AddRoleToEmployee(string roleId, Guid employeeId)
    {
        return HandleResult(await Mediator.Send(new AddRoleToEmployeeCommand { RoleId = roleId, EmployeeId = employeeId}));
    }
    
    [HttpPost("{roleId}/resident/{residentId}")]
    public async Task<IActionResult> AddRoleToResident(string roleId, Guid residentId)
    {
        return HandleResult(await Mediator.Send(new AddRoleToResidentCommand { RoleId = roleId, ResidentId = residentId}));
    }
    
    [HttpDelete("{roleId}/employee/{employeeId}")]
    public async Task<IActionResult> DeleteRoleFromEmployee(string roleId, Guid employeeId)
    {
        return HandleResult(await Mediator.Send(new DeleteRoleFromEmployeeCommand { RoleId = roleId, EmployeeId = employeeId}));
    }
    
    [HttpDelete("{roleId}/resident/{residentId}")]
    public async Task<IActionResult> DeleteRoleFromResident(string roleId, Guid residentId)
    {
        return HandleResult(await Mediator.Send(new DeleteRoleFromResidentCommand { RoleId = roleId, ResidentId = residentId}));
    }
}