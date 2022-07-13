using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Delivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("getAllOrders")]
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var response = await _orderService.GetOrdersAsync();

            return response;
        }

        [HttpPost]
        [Route("insertOrder")]
        public async Task<int> InsertAsync([FromBody] Order entity)
        {
            var response = await _orderService.InsertOrderAsync(entity);

            return response;
        }

        [HttpPut]
        [Route("updateOrder")]
        public async Task<int> UpdateAsync([FromBody] Order entity)
        {
            var response = await _orderService.UpdateOrderAsync(entity);

            return response;
        }

        [HttpDelete]
        [Route("deleteOrder")]
        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _orderService.DeleteOrderAsync(id);

            return response;
        }
    }
}
