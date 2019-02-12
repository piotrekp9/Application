using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Web.Data.Models
{
    [Owned]
    public class ContactInfo
    {
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
