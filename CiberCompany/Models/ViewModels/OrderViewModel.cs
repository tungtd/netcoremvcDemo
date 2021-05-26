using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber_WebUI.Models.ViewModels
{
    public class OrderViewModel
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CustomerName { get; set; }
        public string OrderDate { get; set; }
        public string Amount { get; set; }
    }
}
