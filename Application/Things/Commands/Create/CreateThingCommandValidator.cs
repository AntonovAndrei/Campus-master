using FluentValidation;

namespace Application.Things.Commands.Create;

public class CreateThingCommandValidator: AbstractValidator<CreateThingCommand>
{
    public CreateThingCommandValidator()
    {
        RuleFor(t => t.ThingDto).SetValidator(new ThingDtoValidator());
    }
}