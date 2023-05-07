using Application.Common;
using MediatR;

namespace Application.Roles.Commands.DeleteRoleFromEmployee;

public class DeleteRoleFromEmployeeCommand: IRequest<Result<Unit>>
{
    public Guid EmployeeId { get; set; }
    public string RoleId { get; set; }
}