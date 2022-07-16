using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.Models;
using Service.Interfaces;

namespace Service.Implements
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<int> InsertOrderAsync(Order entity)
        {
            var response = await _orderRepo.InsertAsync(entity);

            return response;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            var response = await _orderRepo.GetAllAsync() ?? new List<Order>();

            return response;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var response = await _orderRepo.DeleteAsync(id);

            return response;
        }

        public async Task<int> UpdateOrderAsync(Order entity)
        {
            var response = await _orderRepo.UpdateAsync(entity);

            return response;
        }
    }
}
