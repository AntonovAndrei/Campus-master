using FluentValidation;

namespace Application.Things;

public class ThingDtoValidator : AbstractValidator<ThingDto>
{
    public ThingDtoValidator()
    {
        RuleFor(n => n.Name)
            .NotEmpty().WithMessage("Name is required.");
    }
}