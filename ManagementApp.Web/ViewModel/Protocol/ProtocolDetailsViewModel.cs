using ManagementApp.Web.ViewModel.Employee;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ManagementApp.Web.ViewModel.Protocol
{
    public class ProtocolDetailsViewModel
    {
        public ProtocolDetailsViewModel(IEnumerable<EmployeeViewModel> employees, IEnumerable<OrderViewModel> orders, ProtocolViewModel protocol)
        {
            Protocol = protocol;
            Employees = new SelectList(employees, "Id", "LastName");
            Orders = new SelectList(orders, "Id", "Title");
        }

        public ProtocolViewModel Protocol { get; set; }

        public SelectList Employees { get; set; }
        public SelectList Orders { get; set; }
    }
}
