using ManagementApp.Web.ViewModel.Employee;
using ManagementApp.Web.ViewModel.Order;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ManagementApp.Web.ViewModel.Protocol
{
    public class ProtocolCreateViewModel
    {
        public ProtocolCreateViewModel(IEnumerable<EmployeeViewModel> employees, IEnumerable<OrderViewModel> orders)
        {
            Employees = new SelectList(employees, "Id", "LastName");
            Orders = new SelectList(orders, "Id", "Title");
        }

        public SelectList Employees { get; set; }
        public SelectList Orders { get; set; }
    }
}
