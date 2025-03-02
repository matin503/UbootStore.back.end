namespace Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

public class PaginationParam
{
    private int _pageIndex;
    private int _pageSize;

    public int PageIndex
    {
        get
        {
            return _pageIndex;
        }
    }

    public int PageSize
    {
        get
        {
            return _pageSize;
        }
    }

    public (int PageNo, int PageSize) PaginationInfo
    {
        set
        {
            _pageIndex = value.PageNo - 1;
            _pageSize = value.PageSize;
        }
    }

    public PaginationModel Pagination
    {
        get
        {
            return new PaginationModel
            {
                PageIndex = _pageIndex,
                PageSize = _pageSize
            };
        }
    }
}
