using Application.Common;
using MediatR;

namespace Application.Things.Commands.Delete;

public class DeleteThingCommand : IRequest<Result<Unit>>
{
    public Guid Id { get; set; }
}