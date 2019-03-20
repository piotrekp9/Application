using ManagementApp.Web.ViewModel.Order;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ManagementApp.Web.ViewModel.Invoice
{
    public class InvoiceCreateViewModel
    {
        public InvoiceCreateViewModel(IEnumerable<ClientViewModel> clients, IEnumerable<OrderViewModel> orders)
        {
            Clients = new SelectList(clients, "Id", "Name");
            Orders = new SelectList(orders, "Id", "Title");
        }

        public SelectList Clients { get; set; }
        public SelectList Orders { get; set; }
    }
}
