using ManagementApp.Web.Data.Enums;
using System;
using System.Collections.Generic;

namespace ManagementApp.Web.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrderType OrderType {get;set;}
        public OrderStatus OrderStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedFinishDate { get; set; }
        public DateTime AcutalFinishDate { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<EmployeesOrders> EmployeesOrders { get; set; }
    }
}
