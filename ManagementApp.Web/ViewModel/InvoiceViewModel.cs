using ManagementApp.Web.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementApp.Web.ViewModel
{
    public class InvoiceViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(1, 99999999999, ErrorMessage ="Wartość musi być większa od 0 i nie większa niż 11 cyfr")]
        public int InvoiceNumber { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public DateTime DateOfIssue { get; set; }
        [Required]
        public int TaxRate { get; set; }
        [Required]
        public decimal PaymentWithoutTax { get; set; }
        [Required]
        public decimal PaymentWithTax { get; set; }
        [Required]
        public decimal TaxPayment { get; set; }
    }
}
