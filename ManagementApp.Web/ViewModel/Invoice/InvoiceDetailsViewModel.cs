using ManagementApp.Web.ViewModel.Order;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ManagementApp.Web.ViewModel.Invoice
{
    public class InvoiceDetailsViewModel
    {
        public InvoiceDetailsViewModel(IEnumerable<ClientViewModel> clients, IEnumerable<OrderViewModel> orders)
        {
            Clients = new SelectList(clients, "Id", "Name");
            Orders = new SelectList(orders, "Id", "Title");
        }
        public InvoiceViewModel Invoice { get; set; }
        public SelectList Clients { get; set; }
        public SelectList Orders { get; set; }
    }
}
 