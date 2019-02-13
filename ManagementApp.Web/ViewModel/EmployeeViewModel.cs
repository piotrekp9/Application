using ManagementApp.Web.Data.Enums;
using ManagementApp.Web.Data.Models;
using System.Collections.Generic;

namespace ManagementApp.Web.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public Address Address { get; set; }
        public ContactInfo ContactInfo { get; set; }

        public ICollection<EmployeesOrders> EmployeesOrders { get; set; }
    }
}
