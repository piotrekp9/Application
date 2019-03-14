using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ManagementApp.Web.ViewModel.Invoice
{
    public class InvoiceDetailsViewModel
    {
        public InvoiceDetailsViewModel(IEnumerable<ClientViewModel> clients)
        {
            Clients = new SelectList(clients, "Id", "Name");
        }
        public InvoiceViewModel Invoice { get; set; }
        public SelectList Clients { get; set; }
    }
}
 