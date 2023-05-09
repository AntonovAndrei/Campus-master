using Application.Common;
using MediatR;

namespace Application.Photos.Queries.Detail;

public class DetailPhotoQuery : IRequest<Result<byte[]>>
{
    public Guid Id { get; set; }
}