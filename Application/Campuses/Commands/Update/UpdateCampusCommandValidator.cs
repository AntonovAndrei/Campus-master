using FluentValidation;

namespace Application.Campuses.Commands.Update;

public class UpdateCampusCommandValidator: AbstractValidator<UpdateCampusCommand>
{
    public UpdateCampusCommandValidator()
    {
        RuleFor(t => t.CampusDto).SetValidator(new CampusDtoValidator());
    }
}