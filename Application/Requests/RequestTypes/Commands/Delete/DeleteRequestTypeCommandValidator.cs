using FluentValidation;

namespace Application.Requests.RequestTypes.Commands.Delete;

public class DeleteRequestTypeCommandValidator : AbstractValidator<DeleteRequestTypeCommand>
{
    public DeleteRequestTypeCommandValidator()
    {
        RuleFor(i => i.Id).NotEqual(Guid.Empty);
    }
}