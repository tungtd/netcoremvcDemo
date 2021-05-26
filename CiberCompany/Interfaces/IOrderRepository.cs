using Ciber_WebUI.Models;
using Ciber_WebUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber_WebUI.Interfaces
{
    public interface IOrderRepository
    {
        Task<Boolean> CreateNewOrderAsync(OrderCreateViewModel order);
        Task<IQueryable<OrderViewModel>> GetAllOrders(string sortOrder , string searchString);       
    }
}
