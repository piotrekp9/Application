using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Web.Data.Models
{
    [Owned]
    public class Address
    {
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
