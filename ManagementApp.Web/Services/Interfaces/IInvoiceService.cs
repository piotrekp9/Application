using ManagementApp.Web.Data.Models;
using System.Collections.Generic;

namespace ManagementApp.Web.Services.Interfaces
{
    public interface IInvoiceService
    {
        IEnumerable<Invoice> GetInvoices();
        Invoice GetInvoiceById(int invoiceId);
        void DeleteInvoice(int invoiceId);
        void AddInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
    }
}
