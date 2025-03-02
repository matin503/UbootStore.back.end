using MediatR;

namespace Uboot.Store.Back.End.Infrastructure.Framework.Mediators;

internal class MediatorService(IMediator _mediator) : IMediatorService
{
    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    public async Task SendAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest
    {
        await _mediator.Send(request, cancellationToken);
    }

    public async Task<object> SendAsync(object request, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(request, cancellationToken);
    }
}
