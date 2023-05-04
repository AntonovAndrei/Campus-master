using Application.Common;
using MediatR;

namespace Application.Campuses.Commands.Delete;

public class DeleteCampusCommand: IRequest<Result<Unit>>
{
    public Guid Id { get; set; }
}