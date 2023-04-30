using Application.Common;
using Application.Users.Residents.Commands.Create;
using MediatR;

namespace Application.Users.Residents.Commands.Update;

public class UpdateResidentCommand : IRequest<Result<Unit>>
{
    public CreateResidentDto ResidentDto { get; set; }
}