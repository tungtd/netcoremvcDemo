using Ciber.DataAccess.Exceptions;
using Ciber_WebUI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CiberCompanyContext _context;
        public OrderRepository(CiberCompanyContext context)
        {
            _context = context;
        }
        public async Task<Boolean> CreateNewOrderAsync(OrderCreateDTO orderVM)
        {
            var product = await _context.Products.FindAsync(orderVM.ProductId);
            if (product == null)
            {
                throw new NotFoundException("No product with this ID", orderVM.ProductId);
            }
            if (product.Quantity < orderVM.Amount)
            {
                return false;
            }
            product.Quantity = product.Quantity - orderVM.Amount;
            Order orderDomain = new Order
            {
                CustomerId = orderVM.CustomerId,
                ProductId = orderVM.ProductId,
                OrderDate = orderVM.OrderDate,
                Amount = orderVM.Amount
            };
            _context.Orders.Add(orderDomain);
            try
            {
                await _context.SaveChangesAsync(new System.Threading.CancellationToken());
            }
            catch (Exception ex)
            {
                throw new ValidationException(string.Format("Error adding order : {0}", ex.Message));
            }

            return true;
        }

        public IQueryable<OrderDTO> GetAllOrders(string sortOrder, string searchString)
        {
            IQueryable<Order> order = _context.Orders.Include("Customer").Include("Product").Include("Product.Category");
            if (!String.IsNullOrEmpty(searchString))
            {
                order = order.Where(r => r.Product.Category.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "prodName_desc":
                    order = order.OrderByDescending(r => r.Product.Name);
                    break;
                case "category":
                    order = order.OrderBy(r => r.Product.Category.Name);
                    break;
                case "category_desc":
                    order = order.OrderByDescending(r => r.Product.Category.Name);
                    break;
                case "customer":
                    order = order.OrderBy(r => r.Customer.Name);
                    break;
                case "customer_desc":
                    order = order.OrderByDescending(r => r.Customer.Name);
                    break;
                case "Date":
                    order = order.OrderBy(r => r.OrderDate);
                    break;
                case "date_desc":
                    order = order.OrderByDescending(r => r.OrderDate);
                    break;
                case "amount":
                    order = order.OrderBy(r => r.Amount);
                    break;
                case "amount_desc":
                    order = order.OrderByDescending(r => r.Amount);
                    break;
                default:
                    order = order.OrderBy(r => r.Product.Name);
                    break;
            }
            return order.Select(x => new OrderDTO
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
