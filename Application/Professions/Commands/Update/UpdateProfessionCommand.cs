using Application.Common;
using MediatR;

namespace Application.Professions.Commands.Update;

public class UpdateProfessionCommand: IRequest<Result<Unit>>
{
    public ProfessionDto ProfessionDto { get; set; }
}