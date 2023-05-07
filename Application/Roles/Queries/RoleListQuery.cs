using Application.Common;
using MediatR;

namespace Application.Roles.Queries;

public class RoleListQuery : IRequest<Result<List<LookupRoleDto>>>
{
}