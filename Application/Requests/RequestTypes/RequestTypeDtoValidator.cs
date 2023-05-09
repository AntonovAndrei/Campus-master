using FluentValidation;

namespace Application.Requests.RequestTypes;

public class RequestTypeDtoValidator  : AbstractValidator<RequestTypeDto>
{
    public RequestTypeDtoValidator()
    {
        RuleFor(n => n.Name)
            .NotEmpty().WithMessage("Name is required.");;
    }
}