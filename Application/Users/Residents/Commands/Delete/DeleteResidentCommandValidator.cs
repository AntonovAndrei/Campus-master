using FluentValidation;

namespace Application.Users.Residents.Commands.Delete;

public class DeleteResidentCommandValidator : AbstractValidator<DeleteResidentCommand>
{
    public DeleteResidentCommandValidator()
    {
        RuleFor(c => c.ResidentId)
            .NotEmpty();
    }
}