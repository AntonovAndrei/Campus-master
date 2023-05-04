using Application.Things;
using Application.Things.Commands.Update;
using FluentValidation;

namespace Application.Professions.Commands.Update;

public class UpdateProfessionCommandValidator: AbstractValidator<UpdateProfessionCommand>
{
    public UpdateProfessionCommandValidator()
    {
        RuleFor(t => t.ProfessionDto).SetValidator(new ProfessionDtoValidator());
    }
}