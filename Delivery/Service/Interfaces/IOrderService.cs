using System.Collections.Generic;
using Domain.Models;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        int InsertOrder(Order entity);

        IEnumerable<Order> GetOrders();

        bool DeleteOrder(int id);

        int UpdateOrder(Order entity);
    }
}
