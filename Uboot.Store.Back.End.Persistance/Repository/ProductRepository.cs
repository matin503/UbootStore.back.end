using Uboot.Store.Back.End.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Uboot.Store.Back.End.Core.Models;
namespace Uboot.Store.Back.End.Persistance.Repository
{
    internal class ProductRepository(UbootStoreContext context) : ABaseRepository(context), IProductRepository
    {
        public  async Task DeleteAsync(int id)
        {
           await _context.Products.Where(x =>x.Id==id).ExecuteDeleteAsync();
        }

        public async Task<ICollection<ProductModel>> GetAllAsync()
        {
            return await _context.Products.ToArrayAsync();
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(ProductModel model)
        {
            await _context.Products.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductModel model)
        {
            _context.Products.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
