using FluentValidation;

namespace Application.Professions.Commands.Delete;

public class DeleteProfessionCommandValidator: AbstractValidator<DeleteProfessionCommand>
{
    public DeleteProfessionCommandValidator()
    {
        RuleFor(i => i.Id).NotEqual(Guid.Empty);
    }
}