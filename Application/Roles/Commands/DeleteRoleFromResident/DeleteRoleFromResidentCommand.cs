using Application.Common;
using MediatR;

namespace Application.Roles.Commands.DeleteRoleFromResident;

public class DeleteRoleFromResidentCommand: IRequest<Result<Unit>>
{
    public Guid ResidentId { get; set; }
    public string RoleId { get; set; }
}