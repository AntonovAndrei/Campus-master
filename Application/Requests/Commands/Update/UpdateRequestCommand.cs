using Application.Common;
using MediatR;

namespace Application.Requests.Commands.Update;

public class UpdateRequestCommand: IRequest<Result<Unit>>
{
    public CreateRequestDto CreateRequestDto { get; set; }
}