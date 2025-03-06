using Uboot.Store.Back.End.Core.Models;
using Uboot.Store.Back.End.Infrastructure.Repository;

namespace Uboot.Store.Back.End.Domain.LogicServices;

internal class SubCategoryLogic(ISubCategoryRepository _subCategoryRepository) : ABaseLogic, ISubCategoryLogic
{
    public async Task DeleteAsync(int id)
    {
        await _subCategoryRepository.DeleteAsync(id);
    }

    public async Task<ICollection<SubCategory>> GetAllAsync()
    {
        return await _subCategoryRepository.GetAllAsync();
    }

    public async Task<SubCategory> GetByIdAsync(int id)
    {
        return await _subCategoryRepository.GetByIdAsync(id);
    }

    public async Task InsertAsync(SubCategory model)
    {
        await _subCategoryRepository.InsertAsync(model);
    }

    public async Task UpdateAsync(SubCategory model)
    {
        await _subCategoryRepository.UpdateAsync(model);
    }
}
