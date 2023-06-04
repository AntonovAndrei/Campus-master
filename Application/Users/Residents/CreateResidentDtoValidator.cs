using FluentValidation;

namespace Application.Users.Residents;

public class CreateResidentDtoValidator : AbstractValidator<CreateResidentDto>
{
    public CreateResidentDtoValidator()
    {
        RuleFor(p => p.Password)
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).+$")
            .WithMessage("Password must contain at least one lowercase letter, one uppercase letter, and one digit.")
            .NotEmpty();
    }
}