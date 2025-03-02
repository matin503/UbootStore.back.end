namespace Uboot.Store.Back.End.Infrastructure.Framework.Mediators;

public interface IMediatorFacade
{
    Task<object> SendAsync<TParam>(TParam param, CancellationToken appStoppingToken);
}
