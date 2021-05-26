using Ciber_WebUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.DataAccess
{
    public interface IOrderRepository
    {
        Task<Boolean> CreateNewOrderAsync(OrderCreateDTO order);
        IQueryable<OrderDTO> GetAllOrders(string sortOrder , string searchString);       
    }
}
