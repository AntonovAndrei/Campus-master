using Domain;
using FluentValidation;

namespace Application.Users.CommonDtos;

public class UserDtoValidator<T> : AbstractValidator<T> where T : UserDto
{
    public UserDtoValidator()
    {
        RuleFor(f => f.FirstName).NotEmpty();
        RuleFor(f => f.LastName).NotEmpty();
        RuleFor(f => f.BirthDate)
            .Must(d=> d > new DateTime(1900,1,1) 
                      && d < DateTime.Now)
            .NotEmpty();
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Number is required.")
            .Matches("^\\d{10}$")
            .WithMessage("Invalid number format. Please enter a valid number containing exactly 10 digits.");
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .Matches("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")
            .WithMessage("Invalid email format.");
        RuleFor(p => p.Passport)
            .NotNull()
            .SetValidator(new PassportDtoValidator());
    }
}