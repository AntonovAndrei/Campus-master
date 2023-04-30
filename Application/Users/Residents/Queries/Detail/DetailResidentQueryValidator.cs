using Application.Users.Employees.Queries.Detail;
using FluentValidation;

namespace Application.Users.Residents.Queries.Detail;

public class DetailResidentQueryValidator : AbstractValidator<DetailResidentQuery>
{
    public DetailResidentQueryValidator()
    {
        RuleFor(x => x.ResidentId).NotEmpty();
    }
}