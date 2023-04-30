using FluentValidation;

namespace Application.Things.Commands.Update;

public class UpdateThingCommandValidator : AbstractValidator<UpdateThingCommand>
{
    public UpdateThingCommandValidator()
    {
        RuleFor(t => t.ThingDto).SetValidator(new ThingDtoValidator());
    }
}