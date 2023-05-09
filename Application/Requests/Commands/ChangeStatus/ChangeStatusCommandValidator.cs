using FluentValidation;

namespace Application.Requests.Commands.ChangeStatus;

public class ChangeStatusCommandValidator : AbstractValidator<ChangeStatusCommand>
{
    public ChangeStatusCommandValidator()
    {
        RuleFor(i => i.RequestId)
            .NotEmpty().NotEqual(Guid.Empty);
    }
}