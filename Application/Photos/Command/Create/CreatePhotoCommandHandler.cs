using Application.Common;
using Application.Interfaces;
using Domain;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Photos.Command.Create;

public class CreatePhotoCommandHandler : IRequestHandler<CreatePhotoCommand, Result<Guid>>
{
    private readonly IPhotoAccessor _photoAccessor;
    private readonly DataContext _context;
    public CreatePhotoCommandHandler(IPhotoAccessor photoAccessor, DataContext context)
    {
        _photoAccessor = photoAccessor;
        _context = context;
    }

    public async Task<Result<Guid>> Handle(CreatePhotoCommand request, CancellationToken cancellationToken)
    {
        var photoUploadResult = await _photoAccessor.AddPhotoAsync(request.File);
        if (photoUploadResult == Guid.Empty)  return Result<Guid>.Failure("Problem adding photo");

        _context.Photos.Add(new Photo() {Id = photoUploadResult});

        var isSaved = await _context.SaveChangesAsync() > 0;
        
        if(!isSaved) return Result<Guid>.Failure("Problem saving info about photo");
        
        return Result<Guid>.Success(photoUploadResult);
    }
}