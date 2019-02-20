using ManagementApp.Web.Data.Enums;
using System;

namespace ManagementApp.Web.ViewModel
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public string Description { get; set; }
        public int AccountNumber { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int TaxRate { get; set; }
        public decimal PaymentWithoutTax { get; set; }
        public decimal PaymentWithTax { get; set; }
        public decimal TaxPayment { get; set; }
    }
}
