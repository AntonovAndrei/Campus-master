using Application.Common;
using MediatR;

namespace Application.Requests.Commands.Create;

public class CreateRequestCommand : IRequest<Result<Guid>>
{
    public CreateRequestDto CreateRequestDto { get; set; }
}