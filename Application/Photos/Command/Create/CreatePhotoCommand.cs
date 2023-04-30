using Application.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Photos.Command.Create;

public class CreatePhotoCommand : IRequest<Result<Guid>>
{
    public IFormFile File { get; set; }
}