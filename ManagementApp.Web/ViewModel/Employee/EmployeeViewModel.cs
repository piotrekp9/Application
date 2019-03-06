using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementApp.Web.ViewModel.Employee
{
    public class EmployeeViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [Required]
        [StringLength(6)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        public bool IsOccupied { get; set; }

        [Required]
        [StringLength(14)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        public IEnumerable<QualificationViewModel> Qualifictaions { get; set; } = new List<QualificationViewModel>();
        public IEnumerable<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();
        public IEnumerable<ProtocolViewModel> Protocols { get; set; } = new List<ProtocolViewModel>();
    }
}
