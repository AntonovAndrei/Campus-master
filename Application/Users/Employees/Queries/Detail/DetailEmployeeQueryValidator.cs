using FluentValidation;

namespace Application.Users.Employees.Queries.Detail;

public class DetailEmployeeQueryValidator : AbstractValidator<DetailEmployeeQuery>
{
    public DetailEmployeeQueryValidator()
    {
        RuleFor(x => x.EmployeeId).NotEmpty();
    }
}