using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uboot.Store.Back.End.Core.Models;

namespace Uboot.Store.Back.End.Infrastructure.Repository
{
    public interface IProductRepository
    {
        Task DeleteAsync(int id);
        Task<SubCategory> GetByIdAsync(int id);
        Task<ICollection<SubCategory>> GetAllAsync();
        Task InsertAsync(SubCategory model);
        Task UpdateAsync(SubCategory model);
    }

}
