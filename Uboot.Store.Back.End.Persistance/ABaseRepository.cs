using Microsoft.EntityFrameworkCore;

namespace Uboot.Store.Back.End.Persistance;

internal abstract class ABaseRepository
{
    public readonly UbootStoreContext _context;

    protected ABaseRepository(UbootStoreContext context)
    {
        _context = context;
        _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
}
