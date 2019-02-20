using ManagementApp.Web.Data.Enums;
using System;

namespace ManagementApp.Web.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderPriority OrderPriority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedFinishDate { get; set; }
        public DateTime AcutalFinishDate { get; set; }
    }
}
