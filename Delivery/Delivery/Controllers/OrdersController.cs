using System.Collections.Generic;
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
        public IEnumerable<Order> GetAll()
        {
            var response =  _orderService.GetOrders();

            return response;
        }

        [HttpPost]
        [Route("insertOrder")]
        public int Insert([FromBody] Order entity)
        {
            var response = _orderService.InsertOrder(entity);

            return response;
        }

        [HttpPut]
        [Route("updateOrder")]
        public int Update([FromBody] Order entity)
        {
            var response = _orderService.UpdateOrder(entity);

            return response;
        }

        [HttpDelete]
        [Route("deleteOrder")]
        public bool Delete(int id)
        {
            var response = _orderService.DeleteOrder(id);

            return response;
        }
    }
}
