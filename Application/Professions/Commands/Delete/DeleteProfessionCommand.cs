using Application.Common;
using MediatR;

namespace Application.Professions.Commands.Delete;

public class DeleteProfessionCommand : IRequest<Result<Unit>>
{
    public Guid Id { get; set; }
}