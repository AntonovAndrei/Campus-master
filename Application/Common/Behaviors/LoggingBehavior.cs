using Application.Common.Interfaces;
using MediatR;
using Serilog;

namespace Application.Common.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest
    : IRequest<TResponse>
{
    IUserAcessor _userAcessor;

    public LoggingBehavior(IUserAcessor userAcessor) =>
        _userAcessor = userAcessor;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _userAcessor.GetUserId();

        Log.Information("Campus Request: {Name} {@UserId} {@Request}",
            requestName, userId, request);

        var response = await next();

        return response;
    }
}
