using ManagementApp.Web.Data.Enums;
using ManagementApp.Web.ViewModel.Employee;
using ManagementApp.Web.ViewModel.Invoice;
using ManagementApp.Web.ViewModel.Protocol;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementApp.Web.ViewModel.Order
{
    public class OrderViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; }
        [Required]
        public OrderPriority OrderPriority { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PlannedFinishDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime AcutalFinishDate { get; set; }

        public EmployeeViewModel Employee { get; set; }
        public ClientViewModel Client { get; set; }
        public InvoiceViewModel Invoice { get; set; }
        public ProductViewModel Product { get; set; }
        public ProtocolViewModel Protocol { get; set; }
    }
}
