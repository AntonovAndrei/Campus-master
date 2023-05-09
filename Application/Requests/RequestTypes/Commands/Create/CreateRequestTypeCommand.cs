using Application.Common;
using MediatR;

namespace Application.Requests.RequestTypes.Commands.Create;

public class CreateRequestTypeCommand: IRequest<Result<Guid>>
{
    public RequestTypeDto RequestTypeDto { get; set; }
}