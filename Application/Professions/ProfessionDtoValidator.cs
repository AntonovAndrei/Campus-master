using FluentValidation;

namespace Application.Professions;

public class ProfessionDtoValidator: AbstractValidator<ProfessionDto>
{
    public ProfessionDtoValidator()
    {
        RuleFor(n => n.Name)
            .NotEmpty().WithMessage("Name is required.");
    }
}