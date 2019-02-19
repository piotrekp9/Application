using System.Collections.Generic;

namespace ManagementApp.Web.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public bool IsOccupied { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ICollection<EmployeesQualifications> EmployeesQualifications { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Protocol> Protocols { get; set; }
    }
}
