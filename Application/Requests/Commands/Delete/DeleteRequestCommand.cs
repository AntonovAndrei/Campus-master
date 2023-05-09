using Application.Common;
using MediatR;

namespace Application.Requests.Commands.Delete;

public class DeleteRequestCommand : IRequest<Result<Unit>>
{
    public Guid Id { get; set; }
}