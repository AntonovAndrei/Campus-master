using FluentValidation;

namespace Application.Requests.Commands.Update;

public class UpdateRequestCommandValidator : AbstractValidator<UpdateRequestCommand>
{
    public UpdateRequestCommandValidator()
    {
        RuleFor(t => t.CreateRequestDto).SetValidator(new CreateRequestDtoValidator());
    }
}