using FluentValidation;

namespace Application.Campuses.Commands.Create;

public class CreateCampusCommandValidator: AbstractValidator<CreateCampusCommand>
{
    public CreateCampusCommandValidator()
    {
        RuleFor(p => p.CampusDto).SetValidator(new CampusDtoValidator());
    }
}