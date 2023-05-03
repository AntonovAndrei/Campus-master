using Application.Common;
using MediatR;

namespace Application.Professions.Commands.Create;

public class CreateProfessionCommand: IRequest<Result<Guid>>
{
    public ProfessionDto ProfessionDto { get; set; }
}