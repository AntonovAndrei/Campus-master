using FluentValidation;

namespace Application.Requests.RequestTypes.Commands.Create;

public class CreateRequestTypeCommandValidator: AbstractValidator<CreateRequestTypeCommand>
{
    public CreateRequestTypeCommandValidator()
    {
        RuleFor(p => p.RequestTypeDto).SetValidator(new RequestTypeDtoValidator());
    }
}