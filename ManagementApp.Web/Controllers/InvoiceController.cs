﻿using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;

namespace ManagementApp.Web.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService) => this.invoiceService = invoiceService;

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
        public IActionResult Create() => View();

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
        public IActionResult Details(int invoiceId)
        {
            if (invoiceId < 1) return BadRequest();
            try
            {
                return View(invoiceService.GetInvoiceById(invoiceId));

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
        public IActionResult Delete(int invoiceId)
        {
            if (invoiceId < 1) return BadRequest();
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
