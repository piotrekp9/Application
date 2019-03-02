using System.ComponentModel.DataAnnotations;

namespace ManagementApp.Web.ViewModel
{
    public class ClientViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Street { get; set; }
        [Required]
        [StringLength(6)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        [StringLength(14)]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Nie poprawny adres email")]
        public string Email { get; set; }
        public string REGON { get; set; }
        [Required]
        public string NIP { get; set; }
        public string PESEL { get; set; }
    }
}
