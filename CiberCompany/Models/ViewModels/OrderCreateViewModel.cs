using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber_WebUI.Models.ViewModels
{
    public class OrderCreateViewModel
    {
        public OrderCreateViewModel()
        {
            OrderName = "";
            ProductId = 0;
            CustomerId = 0;
            Amount = 0;
            OrderDate = DateTime.Now;
        }
        public string OrderName { get; set; }
        [DisplayName("Product")]
        public int ProductId { get; set; }
        [DisplayName("Customer")]
        public int CustomerId { get; set; }
        public IEnumerable<SelectListItem> ProductDropDown { get; set; }
        public IEnumerable<SelectListItem> CustomerDropDown { get; set; }
        public DateTime OrderDate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0!")]
        public int Amount { get; set; }
    }
}
