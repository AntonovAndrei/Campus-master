using FluentValidation;

namespace Application.Things.Commands.Delete;

public class DeleteThingCommandValidator : AbstractValidator<DeleteThingCommand>
{
    public DeleteThingCommandValidator()
    {
        RuleFor(i => i.Id).NotEqual(Guid.Empty);
    }
}