using Application.Common;
using Application.Interfaces;
using Application.Photos.Queries.Detail;
using MediatR;

namespace Application.Photos.Queries.Detail;

public class DetailPhotoQueryHandler : IRequestHandler<DetailPhotoQuery, Result<byte[]>>
{
    private readonly IPhotoAccessor _photoAccessor;

    public DetailPhotoQueryHandler(IPhotoAccessor photoAccessor)
    {
        _photoAccessor = photoAccessor;
    }

    public async Task<Result<byte[]>> Handle(DetailPhotoQuery request, CancellationToken cancellationToken)
    {
        return Result<byte[]>.Success(await _photoAccessor.GetPhotoAsync(request.Id));
    }
}