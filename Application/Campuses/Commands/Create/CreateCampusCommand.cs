using Application.Common;
using MediatR;

namespace Application.Campuses.Commands.Create;

public class CreateCampusCommand: IRequest<Result<Guid>>
{
    public CampusDto CampusDto { get; set; }
}