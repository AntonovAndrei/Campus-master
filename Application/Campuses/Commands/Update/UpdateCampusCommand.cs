using Application.Common;
using MediatR;

namespace Application.Campuses.Commands.Update;

public class UpdateCampusCommand: IRequest<Result<Unit>>
{
    public CampusDto CampusDto { get; set; }
}