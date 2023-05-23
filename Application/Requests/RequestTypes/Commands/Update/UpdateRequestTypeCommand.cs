using Application.Common;
using MediatR;

namespace Application.Requests.RequestTypes.Commands.Update;

public class UpdateRequestTypeCommand: IRequest<Result<Unit>>
{
    public RequestTypeDto RequestTypeDto { get; set; }
}