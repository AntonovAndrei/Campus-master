using Application.Common;
using MediatR;

namespace Application.Things.Commands.Update;

public class UpdateThingCommand : IRequest<Result<Unit>>
{
    public ThingDto ThingDto { get; set; }
}