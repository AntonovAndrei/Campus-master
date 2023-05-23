using FluentValidation;

namespace Application.Requests.RequestTypes.Commands.Update;

public class UpdateRequestTypeCommandValidator: AbstractValidator<UpdateRequestTypeCommand>
{
    public UpdateRequestTypeCommandValidator()
    {
        RuleFor(t => t.RequestTypeDto).SetValidator(new RequestTypeDtoValidator());
    }
}