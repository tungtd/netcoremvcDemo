using Ciber_WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber_WebUI.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducsAsync();
    }
}
