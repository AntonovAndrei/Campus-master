using Application.Common;
using MediatR;

namespace Application.Campuses.Queries.Detail;

public class DetailCampusQuery: IRequest<Result<CampusDto>>
{
    public Guid CampusId { get; set; }
}