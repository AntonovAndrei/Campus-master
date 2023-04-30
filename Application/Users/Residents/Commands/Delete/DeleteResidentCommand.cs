using Application.Common;
using MediatR;

namespace Application.Users.Residents.Commands.Delete;

public class DeleteResidentCommand : IRequest<Result<Unit>>
{
    public Guid ResidentId { get; set; }
}