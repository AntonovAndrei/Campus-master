using Application.Common;
using MediatR;

namespace Application.Photos.Command.Delete;

public class DeletePhotoCommand : IRequest<Result<Unit>>
{
    public Guid Id { get; set; }
}