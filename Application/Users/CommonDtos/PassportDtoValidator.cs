using FluentValidation;

namespace Application.Users.CommonDtos;

public class PassportDtoValidator : AbstractValidator<PassportDto>
{
    public PassportDtoValidator()
    {
        RuleFor(f => f.PassportSeries)
            .Length(4)
            .WithMessage("Длина номера паспорта должна равняться 4")
            .NotEmpty();
        RuleFor(f => f.PassportNumber)
            .Length(6)
            .WithMessage("Длина серии паспорта должна равяться 6")
            .NotEmpty();
        RuleFor(f => f.RegisteredPlace)
            .NotNull();
        RuleFor(f => f.BirthPlace)
            .NotNull();
        // RuleFor(f => f.Gender)
        //     .Must(s => s.Equals("m") || s.Equals("f"))
        //     .WithMessage("Gender must been m or f")
        //     .NotEmpty();
        RuleFor(f => f.IssuedBy)
            .NotEmpty();
        RuleFor(f => f.IssuedCode)
            .NotEmpty();
    }
}