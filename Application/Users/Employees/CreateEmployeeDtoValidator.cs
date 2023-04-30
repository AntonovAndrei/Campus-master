using Application.Users.CommonDtos;
using FluentValidation;

namespace Application.Users.Employees;

public class CreateEmployeeDtoValidator : UserDtoValidator<CreateEmployeeDto>
{
    public CreateEmployeeDtoValidator() 
    {
        RuleFor(f => f.EmploymentDate)
            .Must(d => d > new DateTime(1900, 1, 1)
                       && d < DateTime.Now)
            .NotEmpty();
        RuleFor(p => p.Password)
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).+$")
            .WithMessage("Password must contain at least one lowercase letter, one uppercase letter, and one digit.")
            .NotEmpty();
        RuleFor(l => l.CampusesIds)
            .Must(l => l.Count > 0)
            .WithMessage("An employee must have a campus");
        RuleFor(l => l.ProfessionIds)
            .Must(l => l.Count > 0)
            .WithMessage("An employee must have a profession");
    }
}