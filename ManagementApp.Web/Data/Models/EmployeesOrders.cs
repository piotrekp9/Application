namespace ManagementApp.Web.Data.Models
{
    public class EmployeesOrders
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
