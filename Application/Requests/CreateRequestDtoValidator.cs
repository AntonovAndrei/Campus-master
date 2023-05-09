using FluentValidation;

namespace Application.Requests;

public class CreateRequestDtoValidator : AbstractValidator<CreateRequestDto>
{
    public CreateRequestDtoValidator()
    {
        RuleFor(n => n.Title)
            .NotEmpty().WithMessage("Name is required.");
        RuleFor(i => i.TypeId)
            .NotEmpty().NotEqual(Guid.Empty);
    }
}