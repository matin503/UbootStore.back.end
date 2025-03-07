using Uboot.Store.Back.End.Core.Models;
using Uboot.Store.Back.End.Infrastructure.Repository;

namespace Uboot.Store.Back.End.Domain.LogicServices;

internal class ProductLogic(IProductRepository _ProductRepository) : ABaseLogic, IProductLogic
{
    public async Task DeleteAsync(int id)
    {
        await _ProductRepository.DeleteAsync(id);
    }

    public async Task<SubCategory> GetByIdAsync(int id)
    {
        return await _ProductRepository.GetByIdAsync(id);
    }

    public async Task<ICollection<SubCategory>> GetAllAsync()
    {
        return await _ProductRepository.GetAllAsync();
    }

    public async Task InsertAsync(SubCategory item)
    {
        await _ProductRepository.InsertAsync(item);
    }

    public async Task UpdateAsync(SubCategory item)
    {
        await _ProductRepository.UpdateAsync(item);
    }
}
