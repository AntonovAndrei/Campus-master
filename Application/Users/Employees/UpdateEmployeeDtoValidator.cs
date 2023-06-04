using Application.Users.CommonDtos;
using FluentValidation;

namespace Application.Users.Employees;

public class UpdateEmployeeDtoValidator<T> : UserDtoValidator<T> where T : UpdateEmployeeDto
{
    public UpdateEmployeeDtoValidator()
    {
        RuleFor(l => l.CampusesIds)
            .Must(l => l.Count > 0)
            .WithMessage("An employee must have a campus");
        RuleFor(l => l.ProfessionIds)
            .Must(l => l.Count > 0)
            .WithMessage("An employee must have a profession");
        RuleFor(f => f.EmploymentDate)
            .Must(d => d > new DateTime(1900, 1, 1)
                       && d < DateTime.Now)
            .NotEmpty();
    }
}