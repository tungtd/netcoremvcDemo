using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.DataAccess
{
    public class OrderDTO
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CustomerName { get; set; }
        public string OrderDate { get; set; }
        public string Amount { get; set; }
    }
}
