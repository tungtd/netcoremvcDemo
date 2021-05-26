using System;
using System.Collections.Generic;

#nullable disable

namespace Ciber_WebUI.Entities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public double? Amount { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
