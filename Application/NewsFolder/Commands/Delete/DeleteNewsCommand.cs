using Application.Common;
using MediatR;

namespace Application.NewsFolder.Commands.Delete;

public class DeleteNewsCommand : IRequest<Result<Unit>>
{
    public Guid Id { get; set; }
}