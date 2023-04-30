using Application.Common;
using MediatR;

namespace Application.Users.Employees.Commands.Delete;

public class DeleteEmployeeCommand : IRequest<Result<Unit>>
{
    //все внешние обращения идут через id работника и проживающего а не через UserId
    public Guid EmployeeId { get; set; }
}