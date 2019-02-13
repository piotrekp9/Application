using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Web.Data.Models
{
    [Owned]
    public class ContactInfo
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
