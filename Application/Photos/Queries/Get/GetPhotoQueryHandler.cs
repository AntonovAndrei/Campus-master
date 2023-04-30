using Application.Common;
using Application.Interfaces;
using MediatR;

namespace Application.Photos.Queries.Get;

public class GetPhotoQueryHandler : IRequestHandler<GetPhotoQuery, Result<byte[]>>
{
    private readonly IPhotoAccessor _photoAccessor;

    public GetPhotoQueryHandler(IPhotoAccessor photoAccessor)
    {
        _photoAccessor = photoAccessor;
    }

    public async Task<Result<byte[]>> Handle(GetPhotoQuery request, CancellationToken cancellationToken)
    {
        return Result<byte[]>.Success(await _photoAccessor.GetPhotoAsync(request.Id));
    }
}