using FluentValidation;

namespace Application.Rooms;

public class RoomDtoValidator  : AbstractValidator<RoomDto>
{
    public RoomDtoValidator()
    {
        RuleFor(n => n.Block)
            .NotEmpty().WithMessage("Block is required.");
        RuleFor(n => n.BlockCode)
            .NotEmpty().WithMessage("BlockCode is required.");
    }
}