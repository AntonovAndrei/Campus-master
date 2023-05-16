using FluentValidation;

namespace Application.NewsFolder;

public class CreateNewsDtoValidator : AbstractValidator<NewsDto>
{
    public CreateNewsDtoValidator()
    {
        RuleFor(n => n.Title)
            .NotEmpty().WithMessage("Title is required.");
        RuleFor(n => n.Content)
            .NotEmpty().WithMessage("Content is required.");
    }
}