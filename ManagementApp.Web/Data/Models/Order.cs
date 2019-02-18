using ManagementApp.Web.Data.Enums;
using System;
using System.Collections.Generic;

namespace ManagementApp.Web.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderPriority OrderPriority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedFinishDate { get; set; }
        public DateTime AcutalFinishDate { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ProtocolId { get; set; }
        public Protocol Protocol { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<EmployeesOrders> EmployeesOrders { get; set; }
    }
}
