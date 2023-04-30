using FluentValidation;

namespace Application.Users.Residents.Commands.Update;

public class UpdateResidentCommandValidator : AbstractValidator<UpdateResidentCommand>
{
    public UpdateResidentCommandValidator()
    {
        RuleFor(c => c.ResidentDto)
            .SetValidator(new CreateResidentDtoValidator());
    }
}