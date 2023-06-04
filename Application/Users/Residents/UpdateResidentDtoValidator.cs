using Application.Users.CommonDtos;
using FluentValidation;

namespace Application.Users.Residents;

public class UpdateResidentDtoValidator<T> : UserDtoValidator<T> where T : UpdateResidentDto
{
    public UpdateResidentDtoValidator()
    {
        RuleFor(c => c.CampusId)
            .NotEmpty();
        RuleFor(r => r.RoomId)
            .NotEmpty();
        RuleFor(d => d.GraduationDate)
            .Must(d => d < DateTime.Now)
            .NotEmpty();
    }
}