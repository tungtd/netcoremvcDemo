using Ciber.DataAccess;
using Ciber_WebUI.Models;
using Ciber_WebUI.Models.ViewModels;
using CiberCompany.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiberCompany.Controllers
{
    public class ManageOrdersController : Controller
    {
        private readonly ILogger<ManageOrdersController> _logger;
        private readonly IOrderRepository _orderRepo;
        private readonly ICustomerRepository _custRepo;
        private readonly IProductRepository _prodRepo;
        public ManageOrdersController(ILogger<ManageOrdersController> logger, IOrderRepository orderRepo, ICustomerRepository custRepo, IProductRepository prodRepo)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger.LogTrace("ILogger injected into {0}", nameof(ManageOrdersController));
            _orderRepo = orderRepo;
            _custRepo = custRepo;
            _prodRepo = prodRepo;
        }

        [Authorize(Roles.DIRECTOR, Roles.SUPERVISOR, Roles.ANALYST)]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["ProdNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "prodName_desc" : "";
            ViewData["CategorySortParm"] = sortOrder == "category" ? "category_desc" : "category";
            ViewData["CustomerSortParm"] = sortOrder == "customer" ? "customer_desc" : "customer";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["AmountParm"] = sortOrder == "amount" ? "amount_desc" : "amount";
            ViewData["CurrentFilter"] = searchString;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            int pageSize = 10;

            var result = _orderRepo.GetAllOrders(sortOrder, searchString);
            return View(await PaginatedList<OrderDTO>.CreateAsync(result, pageNumber ?? 1, pageSize));
        }

        [Authorize(Roles.DIRECTOR, Roles.SUPERVISOR)]
        // GET-Create
        public async Task<IActionResult> Create()
        {
            ViewBag.isSuccess = true;
            OrderCreateViewModel orderVM = new OrderCreateViewModel()
            {
                ProductDropDown = (await _prodRepo.GetAllProducsAsync().ConfigureAwait(false)).Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.ProductIdId.ToString()
                }),
                CustomerDropDown = (await _custRepo.GetAllCustomersAsync().ConfigureAwait(false)).Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.CustomerId.ToString()
                }),
            };

            return View(orderVM);
        }

        [Authorize(Roles.DIRECTOR, Roles.SUPERVISOR)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCreateViewModel orderVM)
        {
            bool isSuccess = true;
            if (ModelState.IsValid)
            {
                OrderCreateDTO orderCreateDTO = new OrderCreateDTO
                {
                    CustomerId = orderVM.CustomerId,
                    OrderDate = orderVM.OrderDate,
                    OrderName = orderVM.OrderName,
                    ProductId = orderVM.ProductId,
                    Amount = orderVM.Amount,
                };
                isSuccess = await _orderRepo.CreateNewOrderAsync(orderCreateDTO);
            }
            if (isSuccess)
            {
                return RedirectToAction("Index");
            }
            ViewBag.isSuccess = isSuccess;
            return View(orderVM);
        }
    }
}
