using Application.Common;
using Application.Users.Employees.Commands.Create;
using MediatR;

namespace Application.Users.Employees.Commands.Update;

public class UpdateEmployeeCommand : IRequest<Result<Unit>>
{
    public UpdateEmployeeDto EmployeeDto { get; set; }
}