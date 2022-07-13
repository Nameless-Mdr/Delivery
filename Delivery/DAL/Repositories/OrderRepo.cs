using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _db;

        public OrderRepo(AppDbContext db)
        {
            _db = db;
        }

        public async Task<int> InsertAsync(Order entity)
        {
            await _db.Order.AddAsync(entity);

            return await _db.SaveChangesAsync();
        }

        public Task<List<Order>> GetAllAsync()
        {
            return _db.Order.ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _db.Order.FirstOrDefaultAsync(x => x.Id == id);

            if (order != null)
            {
                _db.Remove(order);

                return await _db.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<int> UpdateAsync(Order entity)
        {
            _db.Update(entity);

            return await _db.SaveChangesAsync();
        }
    }
}
