using System;
using System.Collections.Generic;
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

        public int InsertOrder(Order entity)
        {
            try
            {
                var response = _orderRepo.Insert(entity);

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[InsertOrder]: {e}");

                return 0;
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            try
            {
                var response = _orderRepo.GetAll();

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[GetOrders]: {e}");

                return new List<Order>();
            }
        }

        public bool DeleteOrder(int id)
        {
            try
            {
                var response = _orderRepo.Delete(id);

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[DeleteOrder]: {e}");

                return false;
            }
        }

        public int UpdateOrder(Order entity)
        {
            try
            {
                var response = _orderRepo.Update(entity);

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[UpdateOrder]: {e}");

                return 0;
            }
        }
    }
}
