using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _db;

        public OrderRepo(AppDbContext db)
        {
            _db = db;
        }

        public int Insert(Order entity)
        {
            _db.Order.Add(entity);

            return _db.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Order;
        }

        public bool Delete(int id)
        {
            var order = GetAll().FirstOrDefault(x => x.Id == id);

            if (order != null)
            {
                _db.Remove(order);
                return _db.SaveChanges() > 0;
            }

            return false;
        }

        public int Update(Order entity)
        {
            _db.Update(entity);

            return _db.SaveChanges();
        }
    }
}
