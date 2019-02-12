using System.Collections.Generic;

namespace ManagementApp.Web.Data.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Address Address { get; set; }
        public int? REGON { get; set; }
        public int NIP { get; set; }
        public int? PESEL { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
