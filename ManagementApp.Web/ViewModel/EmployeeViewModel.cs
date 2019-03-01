using System.ComponentModel.DataAnnotations;

namespace ManagementApp.Web.ViewModel
{
    public class EmployeeViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        public string Street { get; set; }
        [Required]
        [StringLength(5)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        public bool IsOccupied { get; set; }
        [Required]
        [StringLength(14)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
    }
}
