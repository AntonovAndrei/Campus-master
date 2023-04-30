using Application.Common;
using MediatR;

namespace Application.Users.Residents.Commands.Create;

public class CreateResidentCommand : IRequest<Result<Guid>>
{
    public CreateResidentDto ResidentDto { get; set; }
}