using Application.Common;
using MediatR;

namespace Application.Photos.Queries.Get;

public class GetPhotoQuery : IRequest<Result<byte[]>>
{
    public Guid Id { get; set; }
}