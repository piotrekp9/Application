using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel;
using ManagementApp.Web.ViewModel.Employee;
using ManagementApp.Web.ViewModel.Invoice;
using ManagementApp.Web.ViewModel.Order;
using ManagementApp.Web.ViewModel.Protocol;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ManagementApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IEmployeeService employeeService;
        private readonly IInvoiceService invoiceService;
        private readonly IProductService productService;
        private readonly IProtocolService protocolService;
        private readonly IClientService clientService;

        public OrderController(
            IOrderService orderService,
            IEmployeeService employeeService,
            IInvoiceService invoiceService,
            IProductService productService,
            IProtocolService protocolService,
            IClientService clientService
            )
        {
            this.orderService = orderService;
            this.employeeService = employeeService;
            this.invoiceService = invoiceService;
            this.productService = productService;
            this.protocolService = protocolService;
            this.clientService = clientService;
        }

        [HttpGet]
        public IActionResult Index(string filter)
        {
            var orders = OrderMapper.MapManyToViewModel(orderService.GetOrders());
            if (string.IsNullOrEmpty(filter)) return View(orders);

            return View(orders.Where(order =>
            order.Title.Contains(filter)));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(OrderViewModel order)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                orderService.AddOrder(OrderMapper.MapToDomainModel(order));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id < 1) return BadRequest();
            try
            {
                var mappedEmployees = EmployeeMapper.MapManyToViewModel(employeeService.GetEmployees());
                if (mappedEmployees == null)
                    mappedEmployees = new List<EmployeeViewModel>();

                var mappedInvoices = InvoiceMapper.MapManyToViewModel(invoiceService.GetInvoices());
                if (mappedInvoices == null)
                    mappedInvoices = new List<InvoiceViewModel>();

                var mappedProducts = ProductMapper.MapManyToViewModel(productService.GetProducts());
                if (mappedProducts == null)
                    mappedProducts = new List<ProductViewModel>();

                var mappedProtocols = ProtocolMapper.MapManyToViewModel(protocolService.GetProtocols());
                if (mappedProtocols == null)
                    mappedProtocols = new List<ProtocolViewModel>();

                var mappedClients = ClientMapper.MapManyToViewModel(clientService.GetClients());
                if (mappedClients == null)
                    mappedClients = new List<ClientViewModel>();

                var order = orderService.GetOrderById(id);
                var mappedOrder = OrderMapper.MapToViewModel(order, order.Employee, order.Client, order.Product, order.Protocol, order.Invoice);

                var orderDetails = new OrderDetailsViewModel(mappedEmployees, mappedClients, mappedProducts, mappedProtocols, mappedInvoices, mappedOrder);

                return View(orderDetails);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Update(OrderViewModel order)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                orderService.UpdateOrder(OrderMapper.MapToDomainModel(order));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id < 1) return BadRequest();
            try
            {
                orderService.DeleteOrder(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}