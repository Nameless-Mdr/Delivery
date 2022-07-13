using System;
using DAL.Interfaces;
using DAL.Repositories;
using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DAL.Tests
{
    [TestClass]
    public class OrderRepoTest
    {
        private readonly DbContextHelper _db;

        public OrderRepoTest(DbContextHelper db)
        {
            _db = db;
        }

        [TestMethod]
        public int Insert()
        {
            var order = new Order
            {
                Id = 1,
                SendCity = "Moscow",
                SendStreet = "Lenina",
                SendHome = 12,
                RecCity = "Ufa",
                RecStreet = "Paradnaya",
                RecHome = 19,
                Weight = 1000,
                DatePickup = new DateTime(2002, 14, 02),
            };

            using (var context = new DbContextHelper())
            {

            }
        }
    }
}
