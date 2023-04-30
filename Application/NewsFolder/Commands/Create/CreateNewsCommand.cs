using Application.Common;
using MediatR;

namespace Application.NewsFolder.Commands.Create;

public class CreateNewsCommand: IRequest<Result<Guid>>
{
    public NewsDto NewsDto { get; set; }
}