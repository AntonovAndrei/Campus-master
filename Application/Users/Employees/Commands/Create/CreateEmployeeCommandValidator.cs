using FluentValidation;

namespace Application.Users.Employees.Commands.Create;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(f => f.EmployeeDto)
            .SetValidator(new CreateEmployeeDtoValidator());
       
    }
}