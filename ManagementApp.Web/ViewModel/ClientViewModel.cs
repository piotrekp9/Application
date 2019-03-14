using ManagementApp.Web.ViewModel.Invoice;
using System.Collections.Generic;
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
        [StringLength(10)]
        public string NIP { get; set; }

        [Required]
        [StringLength(11)]
        public string PESEL { get; set; }

        public IEnumerable<OrderViewModel> Orders = new List<OrderViewModel>();
        public IEnumerable<InvoiceViewModel> Invoices = new List<InvoiceViewModel>();
    }
}