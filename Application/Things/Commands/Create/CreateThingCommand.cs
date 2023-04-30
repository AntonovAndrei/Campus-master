using Application.Common;
using MediatR;

namespace Application.Things.Commands.Create;

public class CreateThingCommand : IRequest<Result<Guid>>
{
    public ThingDto ThingDto { get; set; }
}