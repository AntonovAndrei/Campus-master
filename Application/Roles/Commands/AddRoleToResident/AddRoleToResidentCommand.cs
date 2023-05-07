using Application.Common;
using MediatR;

namespace Application.Roles.Commands.AddRoleToResident;

public class AddRoleToResidentCommand: IRequest<Result<Unit>>
{
    public Guid ResidentId { get; set; }
    public string RoleId { get; set; }
}