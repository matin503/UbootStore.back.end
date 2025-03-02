namespace Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

internal class Response : IResponse
{
    public Status Status { get; internal set; }

    public IEnumerable<string> Messages { get; internal set; }
}

internal class Response<T> : IResponse<T>
{
    public Status Status { get; internal set; }

    public IEnumerable<string> Messages { get; internal set; }

    public T Data { get; internal set; }
}
