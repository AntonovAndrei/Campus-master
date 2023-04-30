using FluentValidation;

namespace Application.Users.Employees.Commands.Delete;

public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(i => i.EmployeeId)
            .NotEqual(Guid.Empty);
    }
}