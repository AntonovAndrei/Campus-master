using FluentValidation;

namespace Application.Professions.Commands.Create;

public class CreateProfessionCommandValidator : AbstractValidator<CreateProfessionCommand>
{
    public CreateProfessionCommandValidator()
    {
        RuleFor(p => p.ProfessionDto).SetValidator(new ProfessionDtoValidator());
    }
}