using Uboot.Store.Back.End.Core.Models;

namespace Uboot.Store.Back.End.Domain.LogicServices;

public interface IProductLogic
{
    Task DeleteAsync(int id);
    Task<ProductModel> GetByIdAsync(int id);
    Task<ICollection<ProductModel>> GetAllAsync();
    Task InsertAsync(ProductModel model);
    Task UpdateAsync(ProductModel model);
}
