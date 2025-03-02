namespace Uboot.Store.Back.End.Infrastructure.Framework.Paginates;

public class PaginationResult<T>(ICollection<T> result, int total)
{
    public ICollection<T> Result { get; set; } = result;
    public int TotalCount { get; set; } = total;
}
