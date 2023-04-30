using FluentValidation;

namespace Application.NewsFolder;

public class NewsDtoValidator : AbstractValidator<NewsDto>
{
    public NewsDtoValidator()
    {
        RuleFor(n => n.Title)
            .NotEmpty().WithMessage("Title is required.");
        RuleFor(n => n.Content)
            .NotEmpty().WithMessage("Content is required.");
    }
}