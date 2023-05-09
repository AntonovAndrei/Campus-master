using Application.Common;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Requests.Commands.Create;

public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, Result<Guid>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IUserAcessor _userAcessor;

    public CreateRequestCommandHandler(DataContext context, IMapper mapper, IUserAcessor userAcessor)
    {
        _context = context;
        _mapper = mapper;
        _userAcessor = userAcessor;
    }

    public async Task<Result<Guid>> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
    {
        //чтобы на стороне бд генерилось, нужно потом отрфакторить
        request.CreateRequestDto.Id = null;
        var req = new Request();
        _mapper.Map(request.CreateRequestDto, req);
        var resident = await _context.Residents
            .Where(r => r.UserId.Equals(_userAcessor.GetUserId()))
            .SingleOrDefaultAsync();
        if (resident == null) return Result<Guid>.Failure("Failed to add request, resident not found");
        req.Resident = resident;

        var type = await _context.RequestTypes
            .Where(r => r.Id.Equals(request.CreateRequestDto.TypeId))
            .SingleOrDefaultAsync();
        if (type == null) return Result<Guid>.Failure("Failed to add request, request type not found");
        req.Type = type;
        
        _context.Requests.Add(req);
        
        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Guid>.Failure("Failed to add request");

        тут должно быть событие  что реквест создался
        
        return Result<Guid>.Success(req.Id);
    }
}