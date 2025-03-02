using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Uboot.Store.Back.End.Infrastructure.Framework.Mediators;

internal class MediatorFacade(IServiceScopeFactory serviceScopeFactory) : IMediatorFacade
{
    private IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

    public async Task<object> SendAsync<TParam>(TParam param, CancellationToken appStoppingToken)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        return await mediator.Send(param, appStoppingToken);
    }
}
