using FluentValidation;

namespace Application.Requests.Commands.Delete;

public class DeleteRequestCommandValidator : AbstractValidator<DeleteRequestCommand>
{
    public DeleteRequestCommandValidator()
    {
        RuleFor(i => i.Id).NotEqual(Guid.Empty);
    }
}