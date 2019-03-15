using ManagementApp.Web.ViewModel.Employee;
using ManagementApp.Web.ViewModel.Invoice;
using ManagementApp.Web.ViewModel.Protocol;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ManagementApp.Web.ViewModel.Order
{
    public class OrderDetailsViewModel
    {
        public OrderDetailsViewModel(
            IEnumerable<EmployeeViewModel> employees, 
            IEnumerable<ClientViewModel> clients, 
            IEnumerable<ProductViewModel> products,
            IEnumerable<ProtocolViewModel> protocols,
            IEnumerable<InvoiceViewModel> invoices,
            OrderViewModel order)
        {
            Order = order;
            Employees = new SelectList(employees, "Id", "LastName");
            Clients = new SelectList(clients, "Id", "Name");
            Products = new SelectList(products, "Id", "Name");
            Protocols = new SelectList(protocols, "Id", "Name");
            Invoices = new SelectList(invoices, "Id", "Description");
        }

        public OrderViewModel Order { get; set; }
        public SelectList Employees { get; set; }
        public SelectList Clients { get; set; }
        public SelectList Products { get; set; }
        public SelectList Protocols { get; set; }
        public SelectList Invoices { get; set; }
    }
}
