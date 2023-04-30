using Application.Common;
using MediatR;

namespace Application.Users.Residents.Queries.Detail;

public class DetailResidentQuery : IRequest<Result<ResidentDto>>
{
    public Guid ResidentId { get; set; }
}