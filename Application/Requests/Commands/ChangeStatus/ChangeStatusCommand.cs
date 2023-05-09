using Application.Common;
using Domain.Enums;
using MediatR;

namespace Application.Requests.Commands.ChangeStatus;

public class ChangeStatusCommand : IRequest<Result<Unit>>
{
    public RequestStatus RequestStatus { get; set; }
    public Guid RequestId { get; set; }
}