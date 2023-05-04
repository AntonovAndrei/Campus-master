using FluentValidation;

namespace Application.Rooms.Commands.Create;

public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(p => p.RoomDto).SetValidator(new RoomDtoValidator());
    }
}