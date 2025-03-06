using Uboot.Store.Back.End.Core.Models;

namespace Uboot.Store.Back.End.Domain.LogicServices;

public interface ISubCategoryLogic
{
    Task DeleteAsync(int id);
    Task<SubCategory> GetByIdAsync(int id);
    Task<ICollection<SubCategory>> GetAllAsync();
    Task InsertAsync(SubCategory model);
    Task UpdateAsync(SubCategory model);
}
