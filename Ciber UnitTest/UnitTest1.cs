using Ciber.DataAccess;
using Ciber_WebUI.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Ciber_UnitTest
{
    public class Tests
    {
        private List<Customer> cusInMemoryDatabase;
        private List<Product> prodInMemoryDatabase;
        private List<Category> cateInMemoryDatabase;
        private IQueryable<OrderDTO> orderInMemoryDatabase;
        private Mock<IOrderRepository> mockorderRepository;
        public IOrderRepository MockOrdersRepository { get; set; }
        [SetUp]
        public void Setup()
        {
            cusInMemoryDatabase = new List<Customer>
            {
                new Customer() {CustomerId = 1, Name = "Cus1"},
                new Customer() {CustomerId = 2, Name = "Cus2"},
                new Customer() {CustomerId = 3, Name = "Cus3"},
            };
            prodInMemoryDatabase = new List<Product>
            {
                new Product(){ProductIdId = 1, Name = "Prod1", CategoryId = 1,Description = "Prod1", Quantity = 100, Price = 1000 },
                new Product(){ProductIdId = 2, Name = "Prod2", CategoryId = 1,Description = "Prod2", Quantity = 10, Price = 1000 },
                new Product(){ProductIdId = 3, Name = "Prod3", CategoryId = 1,Description = "Prod3", Quantity = 100, Price = 1000 },

            };
            cateInMemoryDatabase = new List<Category>
            {
                new Category() {CategoryId = 1, Name = "Cat1"},
            };
            orderInMemoryDatabase = (new List<OrderDTO>
            {
                new OrderDTO(){ProductName = "Prod1", CustomerName = "Cus1", CategoryName = "Cat1", OrderDate = "12-11-2000", Amount = "311.1"},
                new OrderDTO(){ProductName = "Prod2", CustomerName = "Cus2", CategoryName = "Cat1", OrderDate = "12-11-2000", Amount = "233.1"},
                new OrderDTO(){ProductName = "Prod2", CustomerName = "Cus1", CategoryName = "Cat1", OrderDate = "12-11-2000", Amount = "333.1"},
                new OrderDTO(){ProductName = "Prod3", CustomerName = "Cus1", CategoryName = "Cat1", OrderDate = "12-11-2000", Amount = "322.1"},
                new OrderDTO(){ProductName = "Prod1", CustomerName = "Cus1", CategoryName = "Cat1", OrderDate = "12-11-2000", Amount = "301.1"},
            }).AsQueryable();


            string sortOrder = "";
            string searchString = "";
            // Mock the Products Repository using Moq
            mockorderRepository = new Mock<IOrderRepository>();
            mockorderRepository.Setup(mr => mr.GetAllOrders(sortOrder, searchString)).Returns(orderInMemoryDatabase);

            // Complete the setup of our Mock Order Repository
            this.MockOrdersRepository = mockorderRepository.Object;
        }

        [Test]
        public void CanReturnAllOrder()
        {
            string sortOrder = "";
            string searchString = "";
            IList<OrderDTO> testOrders = this.MockOrdersRepository.GetAllOrders(sortOrder, searchString).ToList();
            Assert.IsNotNull(testOrders); // Test if null
            Assert.AreEqual(5, testOrders.Count); // Verify the correct Number            
        }

    }

}