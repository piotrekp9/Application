using ManagementApp.Web.Data.Enums;
using System;

namespace ManagementApp.Web.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public string Description { get; set; }
        public int AccountNumber { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime DateOfIssue { get; set; } // data wystawienia faktury
        public int TaxRate { get; set; }
        public decimal PaymentWithoutTax { get; set; }
        public decimal PaymentWithTax { get; set; }
        public decimal TaxPayment { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
