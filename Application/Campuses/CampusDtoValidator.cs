using FluentValidation;

namespace Application.Campuses;

public class CampusDtoValidator : AbstractValidator<CampusDto>
{
    public CampusDtoValidator()
    {
        RuleFor(n => n.Name)
            .NotEmpty().WithMessage("Name is required.");
        RuleFor(a => a.Address)
            .NotEmpty().WithMessage("Address is required.");
    }
}