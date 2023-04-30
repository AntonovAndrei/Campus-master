using Application.Common;
using Application.Interfaces;
using MediatR;
using Persistence;

namespace Application.Photos.Command.Delete;

public class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand, Result<Unit>>
{
    private readonly IPhotoAccessor _photoAccessor;
    private readonly DataContext _context;

    public DeletePhotoCommandHandler(IPhotoAccessor photoAccessor, DataContext context)
    {
        _photoAccessor = photoAccessor;
        _context = context;
    }

    public async Task<Result<Unit>> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
    {
        var result = await _photoAccessor.DeletePhotoAsync(request.Id);
        
        if(result == Guid.Empty) 
            return Result<Unit>.Failure("Failed to delete photo");

        var photo = _context.Photos.Find(request.Id);
        _context.Photos.Remove(photo);
        var isDeleted = await _context.SaveChangesAsync() > 0;
        
        if(!isDeleted)
            return Result<Unit>.Failure("Failed to delete info about photo");
        
        return Result<Unit>.Success(Unit.Value);
    }
}