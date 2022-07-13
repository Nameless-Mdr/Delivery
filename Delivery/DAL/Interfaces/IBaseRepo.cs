using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace DAL.Interfaces
{
    public interface IBaseRepo<T>
    {
        Task<int> InsertAsync(T entity);

        Task<List<Order>> GetAllAsync();

        Task<bool> DeleteAsync(int id);

        Task<int> UpdateAsync(T entity);
    }
}
