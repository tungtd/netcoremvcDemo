using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciber.DataAccess
{
    public class OrderCreateDTO
    {
        public string OrderName { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Amount { get; set; }
    }
}
