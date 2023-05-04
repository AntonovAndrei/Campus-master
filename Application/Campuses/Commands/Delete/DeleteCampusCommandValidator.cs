using Application.Professions.Commands.Delete;
using FluentValidation;

namespace Application.Campuses.Commands.Delete;

public class DeleteCampusCommandValidator : AbstractValidator<DeleteCampusCommand>
{
    public DeleteCampusCommandValidator()
    {
        RuleFor(i => i.Id).NotEqual(Guid.Empty);
    }
}