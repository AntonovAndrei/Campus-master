using FluentValidation;

namespace Application.Users.Residents;

public class CreateResidentDtoValidator : AbstractValidator<CreateResidentDto>
{
    public CreateResidentDtoValidator()
    {
        RuleFor(d => d.GraduationDate)
            .Must(d => d > DateTime.Now)
            .NotEmpty();
        RuleFor(p => p.Password)
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).+$")
            .WithMessage("Password must contain at least one lowercase letter, one uppercase letter, and one digit.")
            .NotEmpty();
        RuleFor(c => c.CampusId)
            .NotEmpty();
        RuleFor(r => r.RoomId)
            .NotEmpty();
    }
}