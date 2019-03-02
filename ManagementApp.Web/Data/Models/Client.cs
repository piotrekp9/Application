using System.Collections.Generic;

namespace ManagementApp.Web.Data.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string REGON { get; set; }
        public string NIP { get; set; }
        public string PESEL { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
