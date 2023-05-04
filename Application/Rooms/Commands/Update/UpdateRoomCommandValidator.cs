using FluentValidation;

namespace Application.Rooms.Commands.Update;

public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
{
    public UpdateRoomCommandValidator()
    {
        RuleFor(t => t.RoomDto).SetValidator(new RoomDtoValidator());
    }
}