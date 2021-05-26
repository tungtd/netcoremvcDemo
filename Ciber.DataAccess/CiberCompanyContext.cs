using System;
using Ciber_WebUI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ciber.DataAccess
{
    public partial class CiberCompanyContext : DbContext
    {
        public CiberCompanyContext()
        {
        }

        public CiberCompanyContext(DbContextOptions<CiberCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

    }
}
