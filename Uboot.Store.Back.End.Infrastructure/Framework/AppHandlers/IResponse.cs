namespace Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

public interface IResponse
{
    Status Status { get; }

    IEnumerable<string> Messages { get; }
}

public interface IResponse<out T> : IResponse
{
    T Data { get; }
}
