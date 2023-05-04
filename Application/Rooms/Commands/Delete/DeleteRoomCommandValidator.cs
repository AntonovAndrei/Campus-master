using FluentValidation;

namespace Application.Rooms.Commands.Delete;

public class DeleteRoomCommandValidator : AbstractValidator<DeleteRoomCommand>
{
    public DeleteRoomCommandValidator()
    {
        RuleFor(i => i.Id).NotEqual(Guid.Empty);
    }
}