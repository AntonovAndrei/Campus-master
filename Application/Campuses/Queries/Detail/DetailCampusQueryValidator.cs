using FluentValidation;

namespace Application.Campuses.Queries.Detail;

public class DetailCampusQueryValidator : AbstractValidator<DetailCampusQuery>
{
    public DetailCampusQueryValidator()
    {
        RuleFor(x => x.CampusId).NotEmpty();
    }
}