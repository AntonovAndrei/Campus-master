using Application.Common;
using MediatR;

namespace Application.Users.Residents.Commands.Update;

public class UpdateResidentCommand : IRequest<Result<Unit>>
{
    public UpdateResidentDto ResidentDto { get; set; }
}