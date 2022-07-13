using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests
{
    public class DbContextHelper : DbContext
    {
        public DbContextHelper()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=tests;Username=postgres;password=asdfg;Command Timeout=1200;Timeout=60;Maximum Pool Size=30");
        }

        public DbSet<Order> Order { get; set; }
    }
}
