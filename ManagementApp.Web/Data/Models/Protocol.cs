namespace ManagementApp.Web.Data.Models
{
    public class Protocol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}