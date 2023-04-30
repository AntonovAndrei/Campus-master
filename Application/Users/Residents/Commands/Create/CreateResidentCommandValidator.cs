using FluentValidation;

namespace Application.Users.Residents.Commands.Create;

public class CreateResidentCommandValidator : AbstractValidator<CreateResidentCommand>
{
    public CreateResidentCommandValidator()
    {
        RuleFor(r => r.ResidentDto)
            .SetValidator(new CreateResidentDtoValidator());
    }
}