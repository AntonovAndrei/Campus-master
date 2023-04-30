using Application.Common;
using MediatR;

namespace Application.Users.Employees.Queries.Detail;

public class DetailEmployeeQuery : IRequest<Result<EmployeeDto>>
{
    public Guid EmployeeId { get; set; }
}