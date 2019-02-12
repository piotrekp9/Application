namespace ManagementApp.Web.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }


        public Order Order { get; set; }
    }
}
