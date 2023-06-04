using Application.Users.CommonDtos;
using FluentValidation;

namespace Application.Users.Employees;

public class CreateEmployeeDtoValidator : UpdateEmployeeDtoValidator<CreateEmployeeDto>
{
    public CreateEmployeeDtoValidator() 
    {
        RuleFor(p => p.Password)
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).+$")
            .WithMessage("Password must contain at least one lowercase letter, one uppercase letter, and one digit.")
            .NotEmpty();
    }
}