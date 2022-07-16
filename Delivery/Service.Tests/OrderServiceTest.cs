using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Service.Implements;

namespace Service.Tests
{
    [TestClass]
    public class OrderServiceTest
    {
        private Task<IEnumerable<Order>> GetTestOrders()
        {
            var orders = new List<Order>
            {
                new()
                {
                    Id = 1, SendCity = "qwe", SendStreet = "rty", SendHome = 1, RecCity = "asd", RecStreet = "fgh",
                    RecHome = 2
                },
                new()
                {
                    Id = 2, SendCity = "ewq", SendStreet = "ytr", SendHome = 3, RecCity = "dsa", RecStreet = "hgf",
                    RecHome = 4
                },
                new()
                {
                    Id = 3, SendCity = "zxc", SendStreet = "vbn", SendHome = 5, RecCity = "mnb", RecStreet = "vcx",
                    RecHome = 6
                },
            };

            return Task.FromResult<IEnumerable<Order>>(orders);
        }

        private Task<IEnumerable<Order>> GetTestEmptyOrders()
        {
            var orders = new List<Order>
            {
                Capacity = 0
            };

            return Task.FromResult<IEnumerable<Order>>(orders);
        }

        private Task<IEnumerable<Order>> GetTestNull()
        {
            return Task.FromResult<IEnumerable<Order>>(null);
        }

        [TestMethod]
        public void Insert_Order_ReturnId()
        {
            // arrange
            var mock = new Mock<IOrderRepo>();
            var order = new Order
            {
                Id = 2,
                SendCity = "qwe",
                SendStreet = "asd",
                SendHome = 1,
                RecCity = "tyu",
                RecStreet = "ghj",
                RecHome = 2,
                Weight = 1000,
                DatePickup = new DateTime(2002, 02, 14)
            };
            mock.Setup(repo => repo.InsertAsync(order)).Returns(Task.FromResult(2));

            var service = new OrderService(mock.Object);

            // act
            var result = service.InsertOrderAsync(order);

            // assert
            Assert.AreEqual(order.Id, result.Result);
        }

        [TestMethod]
        public void Get_Orders_ReturnsCount()
        {
            // arrange
            var mock = new Mock<IOrderRepo>();
            mock.Setup(repo => repo.GetAllAsync()).Returns(GetTestOrders());
            var service = new OrderService(mock.Object);

            // act
            var result = service.GetOrdersAsync();

            // assert
            Assert.AreEqual(GetTestOrders().Result.Count(), result.Result.Count());
        }

        [TestMethod]
        public void Get_Orders_ReturnsEmpty()
        {
            // arrange
            var mock = new Mock<IOrderRepo>();
            mock.Setup(repo => repo.GetAllAsync()).Returns(GetTestNull());
            var service = new OrderService(mock.Object);

            // act
            var result = service.GetOrdersAsync();

            // assert
            Assert.AreEqual(GetTestEmptyOrders().Result.Count(), result.Result.Count());
        }

        [TestMethod]
        public void Delete_Order_ReturnsTrue()
        {
            // arrange
            var mock = new Mock<IOrderRepo>();
            var order = new Order
            {
                Id = 2,
                SendCity = "qwe",
                SendStreet = "asd",
                SendHome = 1,
                RecCity = "tyu",
                RecStreet = "ghj",
                RecHome = 2,
                Weight = 1000,
                DatePickup = new DateTime(2002, 02, 14)
            };
            mock.Setup(repo => repo.InsertAsync(order));
            mock.Setup(repo => repo.DeleteAsync(2)).Returns(Task.FromResult(true));

            var service = new OrderService(mock.Object);

            // act
            var resultDelete = service.DeleteOrderAsync(2);

            // assert
            Assert.AreEqual(true, resultDelete.Result);
        }

        [TestMethod]
        public void Delete_Order_ReturnsFalse()
        {
            // arrange
            var mock = new Mock<IOrderRepo>();
            var order = new Order
            {
                Id = 2,
                SendCity = "qwe",
                SendStreet = "asd",
                SendHome = 1,
                RecCity = "tyu",
                RecStreet = "ghj",
                RecHome = 2,
                Weight = 1000,
                DatePickup = new DateTime(2002, 02, 14)
            };
            mock.Setup(repo => repo.InsertAsync(order));
            mock.Setup(repo => repo.DeleteAsync(2)).Returns(Task.FromResult(true));

            var service = new OrderService(mock.Object);

            // act
            var resultDelete = service.DeleteOrderAsync(1);

            // assert
            Assert.AreEqual(false, resultDelete.Result);
        }

        [TestMethod]
        public void Update_Order_ReturnId()
        {
            // arrange
            var mock = new Mock<IOrderRepo>();
            var order = new Order
            {
                Id = 1,
                SendCity = "qwe",
                SendStreet = "asd",
                SendHome = 1,
                RecCity = "tyu",
                RecStreet = "ghj",
                RecHome = 2,
                Weight = 1000,
                DatePickup = new DateTime(2002, 02, 14)
            };
            mock.Setup(repo => repo.InsertAsync(order));
            mock.Setup(repo => repo.UpdateAsync(order)).Returns(Task.FromResult(1));

            var service = new OrderService(mock.Object);

            // act
            var result = service.UpdateOrderAsync(order);

            // assert
            Assert.AreEqual(order.Id, result.Result);
        }
    }
}
