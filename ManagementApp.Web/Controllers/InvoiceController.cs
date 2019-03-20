using ManagementApp.Web.Data.Models;
using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel;
using ManagementApp.Web.ViewModel.Invoice;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;

namespace ManagementApp.Web.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService invoiceService;
        private readonly IClientService clientService;
        private readonly IOrderService orderService;

        public InvoiceController(IInvoiceService invoiceService, IClientService clientService, IOrderService orderService)
        {
            this.clientService = clientService;
            this.invoiceService = invoiceService;
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index(string filter)
        {
            var invoices = InvoiceMapper.MapManyToViewModel(invoiceService.GetInvoices());
            if(string.IsNullOrEmpty(filter)) return View(invoices);

            return View(
                invoices.Where(invoice =>
                invoice.InvoiceNumber.ToString().Contains(filter)));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var mappedClients = ClientMapper.MapManyToViewModel(clientService.GetClients());
            var mappedOrders = OrderMapper.MapManyToViewModel(orderService.GetOrders());

            return View(new InvoiceCreateViewModel(mappedClients, mappedOrders));
        }

        [HttpPost]
        public IActionResult Create(InvoiceViewModel client)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                invoiceService.AddInvoice(InvoiceMapper.MapToDomainModel(client));

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
                var clients = clientService.GetClients();
                var orders = orderService.GetOrders();
                var invoice = invoiceService.GetInvoiceById(id);
                var mappedInvoice = InvoiceMapper.MapToViewModel(invoice, invoice.Order, invoice.Client);

                var details = new InvoiceDetailsViewModel(ClientMapper.MapManyToViewModel(clients), OrderMapper.MapManyToViewModel(orders));
                details.Invoice = mappedInvoice;

                return View(details);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public IActionResult Update(InvoiceViewModel invoice)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                invoiceService.UpdateInvoice(InvoiceMapper.MapToDomainModel(invoice));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id < 1) return BadRequest();
            try
            {
                invoiceService.DeleteInvoice(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
