using Application.Common;
using MediatR;

namespace Application.Roles.Commands.AddRoleToEmployee;

public class AddRoleToEmployeeCommand: IRequest<Result<Unit>>
{
    public Guid EmployeeId { get; set; }
    public string RoleId { get; set; }
}