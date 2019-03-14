using ManagementApp.Web.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementApp.Web.ViewModel
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
    }
}
