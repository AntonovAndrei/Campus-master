using Application.Common;
using MediatR;

namespace Application.Requests.RequestTypes.Commands.Delete;

public class DeleteRequestTypeCommand : IRequest<Result<Unit>>
{
    public Guid Id { get; set; }
}