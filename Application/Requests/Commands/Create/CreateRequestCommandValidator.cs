using FluentValidation;

namespace Application.Requests.Commands.Create;

public class CreateRequestCommandValidator : AbstractValidator<CreateRequestCommand>
{
    public CreateRequestCommandValidator()
    {
        RuleFor(p => p.CreateRequestDto).SetValidator(new CreateRequestDtoValidator());
    }
}