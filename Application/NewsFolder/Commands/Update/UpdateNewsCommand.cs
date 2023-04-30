using Application.Common;
using MediatR;

namespace Application.NewsFolder.Commands.Update;

public class UpdateNewsCommand: IRequest<Result<Unit>>
{
    public NewsDto NewsDto { get; set; }
}