using Ciber_WebUI.Interfaces;
using Ciber_WebUI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber_WebUI.Dal.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CiberCompanyContext _context;
        public CustomerRepository(CiberCompanyContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
