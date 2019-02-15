using ManagementApp.Web.Data.Enums;
using System.Collections.Generic;

namespace ManagementApp.Web.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public bool IsOccupied { get; set; }
        public Address Address { get; set; }
        public ContactInfo ContactInfo { get; set; }

        public ICollection<EmployeesOrders> EmployeesOrders { get; set; }
    }
}
