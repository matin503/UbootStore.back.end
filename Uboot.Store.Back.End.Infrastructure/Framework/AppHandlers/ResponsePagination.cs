namespace Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

internal class ResponsePagination : IResponsePagination
{
    public Status Status { get; internal set; }

    public IEnumerable<string> Messages { get; internal set; }
}

public class ResponsePagination<T> : IResponsePagination<T>
{
    public Status Status { get; internal set; }

    public IEnumerable<string> Messages { get; internal set; }

    public T Data { get; internal set; }

    public int TotalItems { get; set; }
}
