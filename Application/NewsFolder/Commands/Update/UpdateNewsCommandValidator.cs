using FluentValidation;

namespace Application.NewsFolder.Commands.Update;

public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand>
{
    public UpdateNewsCommandValidator()
    {
        RuleFor(n => n.NewsDto).SetValidator(new CreateNewsDtoValidator());
    }
}