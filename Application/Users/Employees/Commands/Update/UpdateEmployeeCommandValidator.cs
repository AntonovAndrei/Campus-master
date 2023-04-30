using FluentValidation;

namespace Application.Users.Employees.Commands.Update;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(f => f.EmployeeDto)
            .SetValidator(new CreateEmployeeDtoValidator());
    }
}