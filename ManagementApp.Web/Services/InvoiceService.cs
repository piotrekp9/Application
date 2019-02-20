using ManagementApp.Web.Data;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementApp.Web.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext context;

        public InvoiceService(ApplicationDbContext context) => this.context = context;

        public IEnumerable<Invoice> GetInvoices()
        {
            return context.Invoices
                .Include(invoice => invoice.Order)
                .Include(invoice => invoice.Order)
                .ToList();
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
            return context.Invoices
                .Include(invoice => invoice.Order)
                .Include(invoice => invoice.Client)
                .FirstOrDefault(invoice => invoice.Id == invoiceId);
        }

        public void DeleteInvoice(int invoiceId)
        {
            var invoiceToRemove = context.Invoices.Find(invoiceId);

            if (invoiceToRemove == null) throw new ArgumentException($"There is no invoice of ID:{invoiceId}");

            context.Invoices.Remove(invoiceToRemove);

            context.SaveChanges();
        }

        public void AddInvoice(Invoice invoice)
        {
            if (invoice == null) throw new ArgumentException("Cannot add empty invoice object!");

            context.Invoices.Add(invoice);
            context.SaveChanges();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            var invoiceToUpdate = context.Invoices.Find(invoice.Id);

            if (invoiceToUpdate == null) throw new ArgumentException($"There is no invoice of ID={invoice.Id}, that could be updated");

            invoiceToUpdate.AccountNumber = invoice.AccountNumber;
            invoiceToUpdate.DateOfIssue = invoice.DateOfIssue;
            invoiceToUpdate.Description = invoice.Description;
            invoiceToUpdate.InvoiceNumber = invoice.InvoiceNumber;
            invoiceToUpdate.PaymentType = invoice.PaymentType;
            invoiceToUpdate.PaymentWithoutTax = invoice.PaymentWithoutTax;
            invoiceToUpdate.PaymentWithTax = invoice.PaymentWithTax;
            invoiceToUpdate.TaxPayment = invoice.TaxPayment;
            invoiceToUpdate.TaxRate = invoice.TaxRate;

            context.SaveChanges();
        }
    }
}
