using Microsoft.EntityFrameworkCore;
using Uboot.Store.Back.End.Core.Models;
using Uboot.Store.Back.End.Infrastructure.Repository;

namespace Uboot.Store.Back.End.Persistance.Repository;

internal class SubCategoryRepository(UbootStoreContext context) : ABaseRepository(context),ISubCategoryRepository
{
    public async Task DeleteAsync(int id)
    {
        await _context.SubCategories.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<ICollection<SubCategory>> GetAllAsync()
    {
        return await _context.SubCategories.ToArrayAsync();
    }

    public async Task<SubCategory> GetByIdAsync(int id)
    {
        return await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task InsertAsync(SubCategory model)
    {
        await _context.SubCategories.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(SubCategory model)
    {
        _context.SubCategories.Update(model);
        await _context.SaveChangesAsync();
    }
}
