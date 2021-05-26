using Ciber_WebUI.Interfaces;
using Ciber_WebUI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber_WebUI.Dal.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CiberCompanyContext _context;
        public ProductRepository(CiberCompanyContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
