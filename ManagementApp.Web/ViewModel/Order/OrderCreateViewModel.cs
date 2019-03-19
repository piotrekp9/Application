using ManagementApp.Web.ViewModel.Employee;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ManagementApp.Web.ViewModel.Order
{
    public class OrderCreateViewModel
    {
        public OrderCreateViewModel(IEnumerable<EmployeeViewModel> employees, IEnumerable<ClientViewModel> clients, IEnumerable<ProductViewModel> products)
        {
            Employees = new SelectList(employees, "Id", "LastName");
            Clients = new SelectList(clients, "Id", "Name");
            Products = new SelectList(products, "Id", "Name");
        }

        public SelectList Employees { get; set; }
        public SelectList Clients { get; set; }
        public SelectList Products { get; set; }
    }
}
