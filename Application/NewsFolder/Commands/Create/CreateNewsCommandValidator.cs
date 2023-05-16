using Application.Common;
using FluentValidation;
using MediatR;

namespace Application.NewsFolder.Commands.Create;

public class CreateNewsCommandValidator  : AbstractValidator<CreateNewsCommand>
{
    public CreateNewsCommandValidator()
    {
        RuleFor(n => n.NewsDto).SetValidator(new CreateNewsDtoValidator());
    }
}