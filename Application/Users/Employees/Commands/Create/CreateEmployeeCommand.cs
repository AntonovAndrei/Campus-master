using Application.Common;
using MediatR;

namespace Application.Users.Employees.Commands.Create;

public class CreateEmployeeCommand : IRequest<Result<Guid>>
{
    public CreateEmployeeDto EmployeeDto { get; set; }
}