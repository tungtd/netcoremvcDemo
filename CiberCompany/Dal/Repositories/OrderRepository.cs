using Ciber_WebUI.Interfaces;
using Ciber_WebUI.Models;
using Ciber_WebUI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber_WebUI.Dal.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CiberCompanyContext _context;
        public OrderRepository(CiberCompanyContext context)
        {
            _context = context;
        }
        public async Task<Boolean> CreateNewOrderAsync(OrderCreateViewModel orderVM)
        {
            var product = await _context.Products.FindAsync(orderVM.ProductId);
            if (product.Quantity < orderVM.Quantity)
            {
                return false;
            }
            product.Quantity = product.Quantity - orderVM.Quantity;
            Order orderDomain = new Order
            {
                CustomerId = orderVM.CustomerId,
                ProductId = orderVM.ProductId,
                OrderDate = orderVM.OrderDate,
                Amount = orderVM.Quantity * product.Price
            };
            _context.Orders.Add(orderDomain);
            await _context.SaveChangesAsync(new System.Threading.CancellationToken());
            return true;
        }

        public async Task<IQueryable<OrderViewModel>> GetAllOrders(string sortOrder, string searchString)
        {
            IQueryable<Order> order = _context.Orders.Include("Customer").Include("Product").Include("Product.Category");
            if (!String.IsNullOrEmpty(searchString))
            {
                order = order.Where(r => r.Product.Category.Name.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "prodName_desc":
                    order = order.OrderByDescending(r => r.Product.Name);
                    break;
                case "category_desc":
                    order = order.OrderByDescending(r => r.Product.Category.Name);
                    break;
                case "customer_desc":
                    order = order.OrderByDescending(r => r.Customer.Name);
                    break;
                case "date_desc":
                    order = order.OrderByDescending(r => r.OrderDate);
                    break;
                case "amount_desc":
                    order = order.OrderByDescending(r => r.Amount);
                    break;
                default:
                    order = order.OrderBy(r => r.Product.Name);
                    break;
            }
            return order.Select(x => new OrderViewModel
            {
                ProductName = x.Product.Name,
                CategoryName = x.Product.Category.Name,
                CustomerName = x.Customer.Name,
                OrderDate = x.OrderDate.HasValue ? x.OrderDate.Value.ToString("dd/MM/yyyy") : "",
                Amount = x.Amount.ToString()
            });
        }
    }
}
