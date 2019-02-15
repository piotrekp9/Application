namespace ManagementApp.Web.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
