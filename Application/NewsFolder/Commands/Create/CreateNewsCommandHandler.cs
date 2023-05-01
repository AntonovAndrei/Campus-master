using Application.Common;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.NewsFolder.Commands.Create;

public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, Result<Guid>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IPhotoAccessor _photoAccessor;

    public CreateNewsCommandHandler(DataContext context, IMapper mapper, IPhotoAccessor photoAccessor)
    {
        _context = context;
        _mapper = mapper;
        _photoAccessor = photoAccessor;
    }

    public async Task<Result<Guid>> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
    {
            
        if (request.NewsDto.PhotoIds != null
            && request.NewsDto.PhotoIds.Count > 0)
        {
            List<string> nonExistingPhotos = new List<string>();
                
            foreach (var photoId in request.NewsDto.PhotoIds)
            {
                if(!_photoAccessor.IsPhotoExist(photoId))
                    nonExistingPhotos.Add(photoId);
            }
                
            if(nonExistingPhotos.Count > 0)
                return Result<Guid>.Failure("Photo with such id: " + string.Join(", ", nonExistingPhotos)
                                                                   + " does not exist");
        }

        var news = _mapper.Map<News>(request.NewsDto);
        _context.News.Add(news);

        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Guid>.Failure("Failed to add news");

        return Result<Guid>.Success(news.Id);
    }
}