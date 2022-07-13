using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        Task<int> InsertOrderAsync(Order entity);

        Task<IEnumerable<Order>> GetOrdersAsync();

        Task<bool> DeleteOrderAsync(int id);

        Task<int> UpdateOrderAsync(Order entity);
    }
}
