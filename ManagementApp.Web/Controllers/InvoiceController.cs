using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace ManagementApp.Web.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService) => this.invoiceService = invoiceService;

        [HttpGet]
        public IActionResult Index() => View(InvoiceMapper.MapManyToViewModel(invoiceService.GetInvoices()));

        [HttpPost]
        public IActionResult Create(InvoiceViewModel client)
        {
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
        public IActionResult Details(int invoiceId)
        {
            try
            {
                return View(invoiceService.GetInvoiceById(invoiceId));

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        public IActionResult Update(InvoiceViewModel invoice)
        {
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

        [HttpDelete]
        public IActionResult Delete(int invoiceId)
        {
            try
            {
                invoiceService.DeleteInvoice(invoiceId);
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
