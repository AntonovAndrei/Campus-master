using FluentValidation;

namespace Application.NewsFolder.Commands.Delete;

public class DeleteNewsCommandValidator : AbstractValidator<DeleteNewsCommand>
{
    public DeleteNewsCommandValidator()
    {
        RuleFor(i => i.Id).NotEqual(Guid.Empty);
    }
}